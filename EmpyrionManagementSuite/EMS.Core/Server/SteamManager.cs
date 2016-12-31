using EMS.Core.Util;
using System;
using System.IO;

namespace EMS.Core.Server
{
    /// <summary>
    /// Handles installation and updating of SteamCMD for MP Servers.
    /// </summary>
    public class SteamManager
    {
        private string steamCMDInstaller;
        private bool isInitialized;

        public SteamManager()
        {
            Init();
        }

        private void Init()
        {
            try
            {
                steamCMDInstaller = SettingsManager.Instance().SteamCMDInstallURL;

                if (!Directory.Exists(Constants.SERVER_DIRECTORY))
                {
                    Directory.CreateDirectory(Constants.SERVER_DIRECTORY);
                    DownloadSteamCMD();
                }
                else if (!File.Exists(Constants.SERVER_DIRECTORY + "\\steamcmd.exe"))
                {
                    DownloadSteamCMD();
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void DownloadSteamCMD()
        {
            try
            {

            }
            catch(Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }
    }
}
