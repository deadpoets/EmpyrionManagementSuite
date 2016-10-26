using System.Diagnostics;

namespace EMS.Core.Util
{
    /// <summary>
    /// Returns the assembly version info.
    /// </summary>
    public static class VersionInfo
    {
        /// <summary>
        /// Gets the assembly file version.
        /// </summary>
        public static string FileVersion
        {
            get
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                return fvi.FileVersion;
            }
        }
    }
}