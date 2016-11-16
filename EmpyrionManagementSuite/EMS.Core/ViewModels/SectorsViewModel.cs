using EMS.Core.Libraries;
using EMS.Core.Navigation;
using EMS.Core.Util;
using EMS.DataModels.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Windows;

namespace EMS.Core.ViewModels
{
    public class SectorsViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;
        private SectorsManager sManager;
        public RelayCommand NewSector { get; set; }
        public RelayCommand DeleteSector { get; set; }
        public RelayCommand CopySector { get; set; }

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
                return ((dynamic) Application.Current).GetLocalizationResourceValue("LABEL_SECTORS");
            }
        }

        public string NewSectorTooltip
        {
            get
            {
                return ((dynamic) Application.Current).GetLocalizationResourceValue("TOOLTIP_NEW_SECTOR");
            }
        }

        public string DeleteSectorTooltip
        {
            get
            {
                return ((dynamic) Application.Current).GetLocalizationResourceValue("TOOLTIP_DELETE_SECTOR");
            }
        }

        public string CopySectorTooltip
        {
            get
            {
                return ((dynamic) Application.Current).GetLocalizationResourceValue("TOOLTIP_COPY_SECTOR");
            }
        }

        public List<EMSSector> SectorsList
        {
            get
            {
                return sManager.Sectors;
            }
        }

        private void SetupCommands()
        {
            try
            {
                NewSector = new RelayCommand(AddNewSector);
                DeleteSector = new RelayCommand(DeleteExistingSector);
                CopySector = new RelayCommand(CopyExistingSector);
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
                UIUtil.Alert("ADD A NEW SECTOR");
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
                UIUtil.Alert("DELETE A SECTOR");
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
                UIUtil.Alert("Copy A SECTOR");
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }
    }
}