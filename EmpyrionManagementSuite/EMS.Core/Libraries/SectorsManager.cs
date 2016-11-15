using EMS.Core.Util;
using EMS.DataModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EMS.Core.Libraries
{
    /// <summary>
    /// Handles saving/loading of all user created sectors.
    /// </summary>
    public class SectorsManager : LibrariesManager
    {
        private List<EMSSector> sectors;

        public SectorsManager() : base()
        {
            try
            {
                RebindSectors();
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        public List<EMSSector> Sectors
        {
            get
            {
                return sectors;
            }

            set
            {
                sectors = value;
            }
        }

        /// <summary>
        /// Refreshes the data source by reading the sectors.json file again.
        /// </summary>
        public void RebindSectors()
        {
            try
            {
                if (File.Exists(Constants.LIBRARIES_SECTORS_FILE))
                {
                    sectors = JsonConvert.DeserializeObject<List<EMSSector>>(File.ReadAllText(Constants.LIBRARIES_SECTORS_FILE));
                }
                else
                {
                    UIUtil.Alert(ResourceManager.GetResource("ALERT_NO_SECTORS_EXIST"));
                    sectors = new List<EMSSector>();
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        /// <summary>
        /// Saves/Updates a new sector to the list.
        /// </summary>
        /// <param name="SECTOR"></param>
        public void SaveSector(EMSSector SECTOR)
        {
            try
            {
                // if it already exists, remove it and then re-add the
                // new version
                if (sectors.Contains(sectors.Find(x => x.ID == SECTOR.ID)))
                {
                    sectors.Remove(sectors.Find(x => x.ID == SECTOR.ID));
                }

                sectors.Add(SECTOR);

                File.WriteAllText(Constants.LIBRARIES_SECTORS_FILE, JsonConvert.SerializeObject((sectors.OrderBy(x => x.CreateDate).ToList()), Formatting.Indented));

                UIUtil.Alert(SECTOR.FriendlyName + ResourceManager.GetResource("SECTOR_SAVED_SUCCESS"));
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        /// <summary>
        /// Deletes a user created sector.
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteSector(Guid ID)
        {
            try
            {
                sectors.Remove(sectors.Find(x => x.ID == ID));

                File.WriteAllText(Constants.LIBRARIES_SECTORS_FILE, JsonConvert.SerializeObject((sectors.OrderBy(x => x.CreateDate).ToList()), Formatting.Indented));

                UIUtil.Alert(ResourceManager.GetResource("SECTOR_DELETED_SUCCESS"));
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }
    }
}