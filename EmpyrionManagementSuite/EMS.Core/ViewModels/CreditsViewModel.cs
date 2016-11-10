using EMS.Core.Navigation;
using EMS.Core.Util;
using EMS.DataModels.Models;
using System;
using System.Collections.Generic;

namespace EMS.Core.ViewModels
{
    public class CreditsViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;

        public CreditsViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;
        }

        public List<AppCredit> GetCreditsCollection()
        {
            try
            {
                return CreditsManager.GetCredits();
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }

            return null;
        }
    }
}