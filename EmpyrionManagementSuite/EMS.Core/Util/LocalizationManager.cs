using EMS.DataModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EMS.Core.Util
{
    /// <summary>
    /// Handles smooth transitions of localizations as well as the
    /// Key/Value cache.
    /// </summary>
    public class LocalizationManager
    {
        private Dictionary<string, LocalizationBase> localizations;

        public LocalizationManager()
        {
            localizations = new Dictionary<string, LocalizationBase>();

            BindLocalizations();
        }

        private void BindLocalizations()
        {
            try
            {
                var files = Directory.GetFiles(Constants.LOCALIZATION_DIRECTORY);

                foreach (var filePath in files)
                {
                    try
                    {
                        LocalizationBase loc = JsonConvert.DeserializeObject<LocalizationBase>(File.ReadAllText(filePath));

                        if (loc != null)
                        {
                            localizations.Add(loc.LocalizationCode, loc);
                        }
                    }
                    catch (Exception ex)
                    {
                        AppLogger.Exception(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        public string GetResourceValue(string LOCALIZATIONCODE, string KEY)
        {
            try
            {
                LocalizationBase localization;

                var result = localizations.TryGetValue(LOCALIZATIONCODE, out localization);

                if (result)
                {
                    Resource res = localization.Resources.Find(x => x.Key.ToUpper() == KEY.ToUpper());

                    if (res != null)
                    {
                        return res.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
            // if we get here its because no localization exists with
            // that code, or no key exists within that localization.
            return "[" + LOCALIZATIONCODE + "] <" + KEY + ">";
        }
    }
}