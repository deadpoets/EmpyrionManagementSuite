using EMS.DataModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EMS.Core.Util
{
    /// <summary>
    /// Reads the credits.json file and parses it into a collection.
    /// </summary>
    public static class CreditsManager
    {
        /// <summary>
        /// Parses the credits.json and returns a list.
        /// </summary>
        /// <returns></returns>
        public static List<AppCredit> GetCredits()
        {
            try
            {
                if (File.Exists(Constants.CREDITS_FILE))
                {
                    return JsonConvert.DeserializeObject<List<AppCredit>>(File.ReadAllText(Constants.CREDITS_FILE));
                }
                else
                {
                    throw new FileNotFoundException("The credits file could not be found in the specified directory [" + Constants.CREDITS_FILE + "]", "credits.json");
                }
            }
            catch (FileNotFoundException exF)
            {
                AppLogger.Exception(exF);
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }

            return null;
        }
    }
}