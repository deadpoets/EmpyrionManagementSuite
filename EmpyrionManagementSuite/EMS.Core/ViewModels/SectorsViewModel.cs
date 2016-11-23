using EMS.Core.Libraries;
using EMS.Core.Navigation;
using EMS.Core.Util;
using EMS.DataModels.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace EMS.Core.ViewModels
{
    public class SectorsViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;
        private SectorsManager sManager;
        public RelayCommand NewSector { get; set; }
        public RelayCommand DeleteSector { get; set; }
        public RelayCommand CopySector { get; set; }
        public RelayCommand SaveSector { get; set; }
        public ListBox SectorsListBox { get; set; }

        //SaveButton
        public string SaveButton
        {
            get
            {
                return ResourceManager.GetResource("CONTROL_BUTTON_SAVE");
            }
        }

        //ID
        private string inputID;

        public string InputID { get { return inputID; } set { inputID = value; RaisePropertyChanged("InputID"); } }

        //FriendlyName
        private string inputFriendlyName;

        public string InputFriendlyName { get { return inputFriendlyName; } set { inputFriendlyName = value; RaisePropertyChanged("InputFriendlyName"); } }

        //Owner
        private string inputOwner;

        public string InputOwner { get { return inputOwner; } set { inputOwner = value; RaisePropertyChanged("InputOwner"); } }

        //CreateDate
        private string inputCreateDate;

        public string InputCreateDate { get { return inputCreateDate; } set { inputCreateDate = value; RaisePropertyChanged("InputCreateDate"); } }

        //LastEditDate
        private string inputLastEditDate;

        public string InputLastEditDate { get { return inputLastEditDate; } set { inputLastEditDate = value; RaisePropertyChanged("InputLastEditDate"); } }

        //Contributors
        private string inputContributors;

        public string InputContributors { get { return inputContributors; } set { inputContributors = value; RaisePropertyChanged("InputContributors"); } }

        //URL
        private string inputURL;

        public string InputURL { get { return inputURL; } set { inputURL = value; RaisePropertyChanged("InputURL"); } }

        //Coordinates
        private string inputCoordinates;

        public string InputCoordinates { get { return inputCoordinates; } set { inputCoordinates = value; RaisePropertyChanged("InputCoordinates"); } }

        //Color
        private string inputColor;

        public string InputColor { get { return inputColor; } set { inputColor = value; RaisePropertyChanged("InputColor"); } }

        //Icon
        private string inputIcon;

        public string InputIcon { get { return inputIcon; } set { inputIcon = value; RaisePropertyChanged("InputIcon"); } }

        //Playfields
        private string inputPlayfields;

        public string InputPlayfields { get { return inputPlayfields; } set { inputPlayfields = value; RaisePropertyChanged("InputPlayfields"); } }

        public SectorsViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;
            sManager = new SectorsManager();

            SetupCommands();
        }

        public string SectorsLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_SECTORS");
            }
        }

        public string IDLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_ID");
            }
        }

        public string FriendlyNameLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_FRIENDLY_NAME");
            }
        }

        public string OwnerLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_OWNER");
            }
        }

        public string CreateDateLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_CREATE_DATE");
            }
        }

        public string LastEditDateLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_LAST_EDIT_DATE");
            }
        }

        public string ContributorsLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_CONTRIBUTORS");
            }
        }

        public string URLLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_URL");
            }
        }

        public string CoordinatesLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_COORDINATES");
            }
        }

        public string ColorLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_COLOR");
            }
        }

        public string IconLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_ICON");
            }
        }

        public string PlayfieldsLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_PLAYFIELDS");
            }
        }

        public string NewSectorTooltip
        {
            get
            {
                return ResourceManager.GetResource("TOOLTIP_NEW_SECTOR");
            }
        }

        public string DeleteSectorTooltip
        {
            get
            {
                return ResourceManager.GetResource("TOOLTIP_DELETE_SECTOR");
            }
        }

        public string CopySectorTooltip
        {
            get
            {
                return ResourceManager.GetResource("TOOLTIP_COPY_SECTOR");
            }
        }

        public void RebindSectors()
        {
            try
            {
                SectorsListBox.ItemsSource = SectorsList();
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private List<EMSSector> SectorsList()
        {
            try
            {
                sManager.RebindSectors();
                return sManager.Sectors;
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }

            return null;
        }

        //public string FramePageTitle { get { return framePageTitle; } set { framePageTitle = value; RaisePropertyChanged("FramePageTitle"); } }

        private void SetupCommands()
        {
            try
            {
                // Binding Commands
                NewSector = new RelayCommand(AddNewSector);
                DeleteSector = new RelayCommand(DeleteExistingSector);
                CopySector = new RelayCommand(CopyExistingSector);
                SaveSector = new RelayCommand(UpdateSector);
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        public void SectorsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var sector = (sender as ListBox).SelectedItem as EMSSector;

                WriteDetails(sector);
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void AddNewSector()
        {
            try
            {
                var sector = new EMSSector();
                sector.ID = Guid.NewGuid();
                sector.IsSystemSector = false;
                sector.CreateDate = DateTime.UtcNow;
                sector.LastUpdated = DateTime.UtcNow;
                sector.FriendlyName = "M0rph3u$_0";
                sector.Owner = "MZ";

                var result = sManager.SaveSector(sector);

                if (result)
                {
                    UIUtil.Alert(ResourceManager.GetResource("SECTOR_SAVED_SUCCESS"));
                }
                else
                {
                    UIUtil.Alert(ResourceManager.GetResource("SECTOR_SAVED_FAILED"));
                }

                RebindSectors();
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void UpdateSector()
        {
            try
            {
                if (SectorsListBox.SelectedItems.Count != 0)
                {
                    var sector = SectorsListBox.SelectedItem as EMSSector;

                    sector.LastUpdated = DateTime.UtcNow;
                    sector.Color = InputColor;
                    sector.Contributors = InputContributors.Split('|').ToList();
                    sector.Coordinates = InputCoordinates.Split('|').ToList();
                    sector.FriendlyName = InputFriendlyName;
                    sector.Icon = InputIcon;
                    sector.URL = InputURL;
                    sector.Playfields.Clear();

                    var lines = InputPlayfields.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();

                    if (lines != null)
                    {
                        foreach (var line in lines)
                        {
                            if (!string.IsNullOrEmpty(line))
                            {
                                var itm = line.Split('|').ToList();
                                sector.Playfields.Add(itm);
                            }
                        }
                    }

                    sManager.SaveSector(sector);

                    RebindSectors();
                }
                else
                {
                    UIUtil.Alert(ResourceManager.GetResource("LISTBOX_SELECT_REQUIRED"));
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void DeleteExistingSector()
        {
            try
            {
                if (SectorsListBox.SelectedItems.Count != 0)
                {
                    var sector = SectorsListBox.SelectedItem as EMSSector;

                    sManager.DeleteSector(sector.ID);

                    RebindSectors();
                }
                else
                {
                    UIUtil.Alert(ResourceManager.GetResource("LISTBOX_SELECT_REQUIRED"));
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void CopyExistingSector()
        {
            try
            {
                if (SectorsListBox.SelectedItems.Count != 0)
                {
                    var sector = SectorsListBox.SelectedItem as EMSSector;

                    sManager.CopySector(sector);

                    RebindSectors();
                }
                else
                {
                    UIUtil.Alert(ResourceManager.GetResource("LISTBOX_SELECT_REQUIRED"));
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void WriteDetails(EMSSector SECTOR)
        {
            try
            {
                if (SECTOR != null)
                {
                    InputID = SECTOR.ID.ToString().ToUpper();
                    InputFriendlyName = SECTOR.FriendlyName;
                    InputOwner = SECTOR.Owner;
                    InputCreateDate = SECTOR.CreateDate.ToString();
                    InputLastEditDate = SECTOR.LastUpdated.ToString();
                    InputContributors = string.Join("|", SECTOR.Contributors != null ? SECTOR.Contributors.ToArray() : new string[1]);
                    InputURL = SECTOR.URL;
                    InputCoordinates = string.Join("|", SECTOR.Coordinates != null ? SECTOR.Coordinates.ToArray() : new string[1]);
                    InputColor = SECTOR.Color;
                    InputIcon = SECTOR.Icon;

                    InputPlayfields = "";

                    if (SECTOR.Playfields != null)
                    {
                        foreach (var itm in SECTOR.Playfields)
                        {
                            InputPlayfields += string.Join("|", itm != null ? itm.ToArray() : new string[1]) + Environment.NewLine;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }
    }
}