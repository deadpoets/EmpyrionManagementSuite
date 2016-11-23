using EMS.Core.Libraries;
using EMS.DataModels.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EMS.Tests.SectorsManagerTests
{
    /// <summary>
    /// All tests for the SectorsManager library manager.
    /// </summary>
    [TestFixture]
    public class SectorsManagerTests
    {
        /// <summary>
        /// Returns a generic SectorsManager object.
        /// </summary>
        /// <returns></returns>
        private SectorsManager GetSectorsManager()
        {
            return new SectorsManager();
        }

        private EMSSector GetGenericSector()
        {
            var sector = new EMSSector();
            sector.ID = Guid.NewGuid();
            sector.AllowModifications = false;
            sector.Color = "0.5,0.1,0.3";
            sector.Contributors = new List<string>();
            sector.Contributors.Add("morpheuszero");
            sector.Coordinates = new List<string>();
            sector.Coordinates.Add("1000,5000,10000");
            sector.CreateDate = DateTime.UtcNow;
            sector.FriendlyName = "MORPHEUSZERO_FRIENDLY";
            sector.Icon = "Circle";
            sector.IsSystemSector = false;
            sector.LastUpdated = DateTime.UtcNow.AddHours(1.25);
            sector.Owner = "dylanlegendre09@gmail.com";
            sector.Playfields = new List<List<string>>();
            sector.URL = "www.github.com";

            return sector;
        }

        [Test]
        public void InstantiateSectorsManager()
        {
            var sManager = GetSectorsManager();

            Assert.NotNull(sManager, "[SectorsManager] could not be instantiated.");
        }

        [Test]
        public void CreateGenericSector()
        {
            var sector = GetGenericSector();

            Assert.NotNull(sector, "The generic sector could not be created.");
        }

        [Test]
        public void SaveSector()
        {
            var result = GetSectorsManager().SaveSector(GetGenericSector());

            Assert.IsTrue(result, "The sector could not be saved!");
        }

        [Test]
        public void DeleteSector()
        {
            var sManager = GetSectorsManager();

            if (sManager.Sectors != null)
            {
                if (sManager.Sectors.Count > 0)
                {
                    var sector = sManager.Sectors[0];

                    //TODO: finish this.
                }
            }
        }
    }
}