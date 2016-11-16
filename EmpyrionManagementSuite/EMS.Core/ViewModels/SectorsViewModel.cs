﻿using EMS.Core.Libraries;
using EMS.Core.Navigation;
using EMS.Core.Util;
using EMS.DataModels.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Windows;
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
        public ListBox SectorsListBox { get; set; }

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
                return ((dynamic)Application.Current).GetLocalizationResourceValue("LABEL_SECTORS");
            }
        }

        public string NewSectorTooltip
        {
            get
            {
                return ((dynamic)Application.Current).GetLocalizationResourceValue("TOOLTIP_NEW_SECTOR");
            }
        }

        public string DeleteSectorTooltip
        {
            get
            {
                return ((dynamic)Application.Current).GetLocalizationResourceValue("TOOLTIP_DELETE_SECTOR");
            }
        }

        public string CopySectorTooltip
        {
            get
            {
                return ((dynamic)Application.Current).GetLocalizationResourceValue("TOOLTIP_COPY_SECTOR");
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

                UIUtil.Alert(sector.ID.ToString());
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
                sector.FriendlyName = "Morph3us_0";

                sManager.SaveSector(sector);

                RebindSectors();
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
    }
}