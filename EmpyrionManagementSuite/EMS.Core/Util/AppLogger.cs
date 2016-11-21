using EMS.DataModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EMS.Core.Util
{
    /// <summary>
    /// Handles logging all messages and exceptions.
    /// </summary>
    public static class AppLogger
    {
        /// <summary>
        /// Logs a simple INFO message to the application log.
        /// </summary>
        /// <param name="Message"></param>
        public static void Info(string MESSAGE)
        {
            try
            {
                CheckExists();

                var log = new ApplicationLog();
                log.Message = MESSAGE;
                log.Date = DateTime.UtcNow;
                log.Type = "INFO";

                WriteLog(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Logs a simple INFO message to the application log.
        /// </summary>
        /// <param name="Message"></param>
        public static void Info(string MESSAGE, string ADDITIONALINFO)
        {
            try
            {
                CheckExists();

                var log = new ApplicationLog();
                log.Message = MESSAGE;
                log.AdditionalInfo = ADDITIONALINFO;
                log.Date = DateTime.UtcNow;
                log.Type = "INFO";

                WriteLog(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Logs an exception message to the application log.
        /// </summary>
        /// <param name="Message"></param>
        public static void Exception(Exception EX)
        {
            try
            {
                CheckExists();

                var log = new ApplicationLog();
                log.Message = EX.Message;
                log.Source = EX.Source;
                log.StackTrace = EX.StackTrace;
                log.AdditionalInfo = EX.TargetSite.Name;
                log.Date = DateTime.UtcNow;
                log.Type = "EXCEPTION";

                WriteLog(log);

                UIUtil.Alert(EX.Message + Environment.NewLine + Environment.NewLine + EX.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Actually writes the log to the json file and stores it on disk.
        /// </summary>
        /// <param name="LOG"></param>
        private static void WriteLog(ApplicationLog LOG)
        {
            try
            {
                var lst = new List<ApplicationLog>();

                if (File.Exists(Constants.LOGS_LOG_FILE))
                {
                    var rawData = File.ReadAllText(Constants.LOGS_LOG_FILE);

                    lst = JsonConvert.DeserializeObject<List<ApplicationLog>>(rawData);

                    // add the new log to the list, then write it all back.
                    lst.Add(LOG);
                }
                else
                {
                    lst = new List<ApplicationLog>();
                    lst.Add(LOG);
                }

                File.WriteAllText(Constants.LOGS_LOG_FILE, JsonConvert.SerializeObject(lst, Formatting.Indented));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Determines if the logs directory exists, if not--creates it.
        /// </summary>
        private static void CheckExists()
        {
            try
            {
                if (!Directory.Exists(Constants.LOGS_DIRECTORY))
                {
                    Directory.CreateDirectory(Constants.LOGS_DIRECTORY);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}