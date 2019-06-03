using EMS.Core.Util;
using System;
using System.IO;

namespace EMS.Core.Libraries
{
    /// <summary>
    /// A base class for all libraries that will make sure the
    /// directory is created if it doesn't exist.
    /// </summary>
    [Obsolete("Please implement ILibrary instead.", true)]
    public class LibrariesManager
    {
        public LibrariesManager()
        {
            Start();
        }

        private void Start()
        {
            try
            {
                if (!Directory.Exists(Constants.LIBRARIES_DIRECTORY))
                {
                    Directory.CreateDirectory(Constants.LIBRARIES_DIRECTORY);
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }
    }
}