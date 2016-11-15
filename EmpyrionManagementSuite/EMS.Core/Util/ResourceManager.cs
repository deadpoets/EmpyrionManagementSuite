using System;
using System.Windows;

namespace EMS.Core.Util
{
    /// <summary>
    /// Makes calls to the localization file to retrieve strings based
    /// on a key.
    /// </summary>
    public static class ResourceManager
    {
        /// <summary>
        /// Get the localization string based on a defined key name.
        /// </summary>
        /// <param name="KEY"></param>
        /// <returns></returns>
        public static string GetResource(string KEY)
        {
            try
            {
                return ((dynamic) Application.Current).GetLocalizationResourceValue(KEY);
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }

            return null;
        }
    }
}