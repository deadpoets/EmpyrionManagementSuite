using System;
using System.Windows;

namespace EMS.Core.Util
{
    /// <summary>
    /// A few helper functions to be used for UI purposes.
    /// </summary>
    public static class UIUtil
    {
        /// <summary>
        /// Shows a standard alert box message.
        /// </summary>
        /// <param name="MESSAGE"></param>
        public static void Alert(string MESSAGE)
        {
            try
            {
                MessageBox.Show(MESSAGE, ResourceManager.GetResource("APP_NAME"), MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }
    }
}