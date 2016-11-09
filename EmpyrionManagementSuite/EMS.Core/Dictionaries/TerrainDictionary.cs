using EMS.Core.Util;
using EMS.DataModels.Models;
using System;
using System.Collections.Generic;

namespace EMS.Core.Dictionaries
{
    /// <summary>
    /// Holds constants for the values that can be used for terrain blocks such as plants, etc.
    /// </summary>
    public class TerrainDictionary
    {
        private Dictionary<string, TerrainItem> Items;

        public TerrainDictionary()
        {
            BuildTerrainDictionary();
        }

        private void BuildTerrainDictionary()
        {
            try
            {
                //TODO: read from .json file to get all info from file that will be updated as new content is released.
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }
    }
}