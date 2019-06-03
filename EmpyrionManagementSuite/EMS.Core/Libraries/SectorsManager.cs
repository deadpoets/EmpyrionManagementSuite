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
    public class SectorsManager : ILibrary
    {
        private List<EMSSector> sectors;

        public SectorsManager()
        {
            try
            {
                Start();
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        public void Start()
        {
            try
            {
                if (!Directory.Exists(Constants.LIBRARIES_DIRECTORY))
                {
                    Directory.CreateDirectory(Constants.LIBRARIES_DIRECTORY);
                }

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
        /// <returns>success result is returned.</returns>
        public bool SaveSector(EMSSector SECTOR)
        {
            var success = false;

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

                success = true;
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }

            return success;
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
                UIUtil.Alert(ResourceManager.GetResource("SECTOR_DELETED_FAIL") + ex.Message);
            }
        }

        /// <summary>
        /// Creates a new sector based on an existing one.
        /// </summary>
        /// <param name="ID"></param>
        public void CopySector(EMSSector SECTOR)
        {
            try
            {
                var sector = new EMSSector();
                sector.ID = Guid.NewGuid();
                sector.CreateDate = DateTime.UtcNow;
                sector.FriendlyName = SECTOR.FriendlyName + "_COPY";
                sector.AllowModifications = SECTOR.AllowModifications;
                sector.Color = SECTOR.Color;
                sector.Contributors = SECTOR.Contributors;
                sector.Coordinates = SECTOR.Coordinates;
                sector.Icon = SECTOR.Icon;
                sector.IsSystemSector = false;
                sector.LastUpdated = DateTime.UtcNow;
                sector.Owner = SECTOR.Owner;
                sector.Playfields = SECTOR.Playfields;
                sector.URL = SECTOR.URL;

                sectors.Add(sector);

                File.WriteAllText(Constants.LIBRARIES_SECTORS_FILE, JsonConvert.SerializeObject((sectors.OrderBy(x => x.CreateDate).ToList()), Formatting.Indented));

                UIUtil.Alert(ResourceManager.GetResource("SECTOR_SAVED_SUCCESS"));
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
                UIUtil.Alert(ResourceManager.GetResource("SECTOR_SAVED_FAILED") + ex.Message);
            }
        }
    }
}