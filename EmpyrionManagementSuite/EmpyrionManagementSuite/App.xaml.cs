using EmpyrionManagementSuite.Themes;
using EMS.Core.Util;
using EMS.DataModels.Models;
using System;
using System.Windows;
using System.Windows.Threading;

namespace EmpyrionManagementSuite
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private LocalizationManager localizationManager;
        private AppSettings settings;

        public AppSettings Settings
        {
            get
            {
                return settings;
            }
            set
            {
                settings = value;
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DispatcherUnhandledException += App_DispatcherUnhandledException;

            try
            {
                // Initially always use dark theme, we can change it
                // later from loaded user settings.
                ChangeTheme(ThemeType.MORPHEUS_DARK);

                // Initialize the settings file.
                settings = SettingsManager.Init();

                // Initialize the localization manager
                localizationManager = new LocalizationManager();
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            //AlertBox.Exception("An unhandled exception occurred. Please report this error message to GitHub Issues tracker if it continues. [" + e.Exception.Message + "]");
        }

        private ResourceDictionary ThemeDictionary
        {
            get { return Resources.MergedDictionaries[0]; }
        }

        public void ChangeTheme(ThemeType TYPE)
        {
            try
            {
                var uri = new Uri(THEME.GetThemePath(TYPE), UriKind.RelativeOrAbsolute);

                ThemeDictionary.MergedDictionaries.Clear();
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        /// <summary>
        /// Returns the localization string from the resources file for
        /// the active localization.
        /// </summary>
        /// <param name="KEY"></param>
        /// <returns></returns>
        public string GetLocalizationResourceValue(string KEY)
        {
            try
            {
                return localizationManager.GetResourceValue(settings.LocalizationCode, KEY);
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }

            return "[LOCALIZATION ERROR] <" + KEY + ">";
        }
    }
}