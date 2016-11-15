using System;

namespace EMS.Core.Util
{
    /// <summary>
    /// Constants used by the application globally such as file paths, etc.
    /// </summary>
    public static class Constants
    {
        public static string BASE_DIRECTORY = AppDomain.CurrentDomain.BaseDirectory;
        public static string APPSETTINGS_FILE = BASE_DIRECTORY + "settings.json";
        public static string LOGS_DIRECTORY = BASE_DIRECTORY + "logs";
        public static string LIBRARIES_DIRECTORY = BASE_DIRECTORY + "libraries";
        public static string LIBRARIES_SECTORS_FILE = LIBRARIES_DIRECTORY + "\\sectors.json";
        public static string LOGS_LOG_FILE = LOGS_DIRECTORY + "\\logs.json";
        public static string CREDITS_FILE = BASE_DIRECTORY + "credits.json";
        public static string LOCALIZATION_DIRECTORY = BASE_DIRECTORY + "Localizations";
        public static string TEMP_DIR = BASE_DIRECTORY + "tmp";
        public static string BAK_DIR = BASE_DIRECTORY + "bak";
        public static string UPDATE_JSON_URL = "https://raw.githubusercontent.com/MorpheusZero/EmpyrionManagementSuite/master/update.json";
        public static string HOME_DASHBOARD_URL = "http://empyrionmanagementsuite.tumblr.com/";
    }
}