using EmpyrionManagementSuite.Themes;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DispatcherUnhandledException += App_DispatcherUnhandledException;

            // Initially always use dark theme, we can change it later from loaded user settings.
            ChangeTheme(ThemeType.MORPHEUS_DARK);
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
            var uri = new Uri(THEME.GetThemePath(TYPE), UriKind.RelativeOrAbsolute);

            ThemeDictionary.MergedDictionaries.Clear();
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
        }
    }
}