using System.Collections.Generic;

namespace EMS.DataModels.Models
{
    /// <summary>
    /// Defines an Eleon Playfield Model
    /// </summary>
    public class Playfield
    {
        public double RealRadius { get; set; }
        public int ScaledRadius { get; set; }
        public double Gravity { get; set; }
        public double AtmosphereDensity { get; set; }
        public double AtmosphereO2 { get; set; }
        public bool AtmosphereBreathable { get; set; }
        public int Temperature { get; set; }
        public int TemperatureDay { get; set; }
        public int TemperatureNight { get; set; }
        public int DayLength { get; set; }
        public string PlanetType { get; set; }
        public string Water { get; set; }
        public int SeaLevel { get; set; }
        public bool Emissive { get; set; }
        public bool PvP { get; set; }
        public long Seed { get; set; }
        public bool UseFixed { get; set; }
        public int Difficulty { get; set; }
        public string PlayfieldType { get; set; }
        public string SunFlare { get; set; }

        //TODO: need to normalize
        public object LocalEffect { get; set; }

        //# Special Effects                   # Please don't change
        //LocalEffect:
        //    Name: EnvironmentalEffects/Grime
        //    MaxHeight: 200

        public bool AtmosphereEnabled { get; set; }
        public string AtmosphereColor { get; set; }
        public string SkyColor { get; set; }
        public string LightZenithColor { get; set; }
        public string LightHorizonColor { get; set; }
        public double DayLightIntensity { get; set; }
        public double NightLightIntensity { get; set; }
        public double DayShadowStrength { get; set; }
        public double NightShadowStrength { get; set; }
        public double AtmosphereFog { get; set; }
        public double FogCloudIntensity { get; set; }
        public double FogIntensity { get; set; }
        public int FogStartDistance { get; set; }
        public double GroundFogIntensity { get; set; }
        public int GroundFogHeight { get; set; }
        public double CloudsDensity { get; set; }
        public double CloudsSharpness { get; set; }
        public double CloudsBrightness { get; set; }
        public double CloudsOpacity { get; set; }
        public string CloudsZenithColor { get; set; }
        public string CloudsHorizonColor { get; set; }
        public int WindSpeed { get; set; }

        //TODO: normalize object
        public List<object> FixedResources { get; set; }

        //### Fixed Resources for Seed=0      # No functionality in Seed>0 games
        //# pos, radius, name
        //FixedResources:
        //    - Name: IronResource
        //      Pos: [ -333, 72, -552 ]
        //        Radius: 10

        //    - Name: CobaltResource
        //      Pos: [ 1859, 94 ,1042 ]
        //        Radius: 9

        //    - Name: MagnesiumResource
        //      Pos: [ 86, 32, 638 ]
        //        Radius: 6

        //TODO: normalize object
        public List<object> RandomResources { get; set; }

        //### Randomly distributed resources    # For Seed>0 games     # Please don't change
        //RandomResources:
        //    - Name: ErestrumResource
        //      CountMinMax: [ 5, 8 ]   # range of number of resources to distribute on planet
        //      SizeMinMax: [ 8, 14 ]  # range of sizes of resource depots
        //      DepthMinMax: [ 0, 1 ]   # Range of how deep to bury depots below terrain surface (e.g. 0 = partly visible, 3 = top of depot starts 3m below surface)
        //      DroneProb: 0.4          # probability that the resource is defended by drones
        //      MaxDroneCount: 1        # if at all, 1..n drones will defend the resource [default = 1]

        //    - Name: SathiumResource
        //      CountMinMax: [ 4, 7 ]
        //      SizeMinMax: [ 8, 13 ]
        //      DepthMinMax: [ 0, 1 ]
        //      DroneProb: 0.4

        //    - Name: PromethiumResource
        //      CountMinMax: [ 2, 3 ]
        //      SizeMinMax: [ 8, 13 ]
        //      DepthMinMax: [ 0, 1 ]
        //      DroneProb: 0.4

        //    - Name: GoldResource
        //      CountMinMax: [ 3, 4 ]
        //      SizeMinMax: [ 3, 6 ]
        //      DepthMinMax: [ 0, 15 ]
        //      DroneProb: 0.9

        //### Terrain and Decorations
        //# Terrain and Local Decoration

        //TODO: normalize object
        public object Terrain { get; set; }

        //Terrain:
        //    Name: Lava
        //    PoleLevel: 28                       # Pole level of planet
        //    NoiseStrength: 0.3
        //    ColorChange:
        //        YFadeCenter: 80
        //        YFadeRange: 40
        //        YFadeMin: -0.15
        //        YFadeMax: 0.2

        //TODO: normalize object
        public object MainBiome { get; set; }

        //MainBiome:
        //    Textures:
        //        - [ RockGrey08, 1 ]
        //        - [ RockLava05, 4 ]
        //        - [ RockLava04, 0 ]
        //        - [ BedrockLava, 2 ]

        //    Decorations:
        //        - [ RocksmallA02, 0.3 ]
        //        - [ RocksmallC01, 0.3 ]
        //        - [ Rocks05, 0.1 ]

        //TODO: normalize object
        public object SubBiomes { get; set; }

        //SubBiomes:
        //    - Altitude: 40
        //      Textures:
        //        - [ RockGrey08Lava, 13 ]
        //      Decorations:
        //        - [ RocksmallA02, 0.2 ]
        //        - [ RocksmallC01, 0.2 ]

        //TODO: normalize object
        public object Biome { get; set; }

        //# Biome Definition and Main Decoration
        //Biome:
        //# Plains
        //   - Altitude: [ 40, 95 ]
        //     Slope: [ 0, 20 ]
        //     BiomeClusterData:
        //         - Name: "LavaPlains"
        //           Id: 1
        //           ClusterSize: 80
        //           NbOfClusters: 30
        //           Decorations:
        //               - [ "AlienPlant11", 0.2]
        //               - [ "AlienPlantThorn2", 0.5]
        //               # - [ "AridRock02", 0.2]
        //               # - [ "AridRock03", 0.2]
        //               # - [ "GasEmitter1", 0.02]
        //               - [ "RealRock2", 0.02]
        //               - [ "RealRock4", 0.02]
        //               - [ "RealRock10", 0.01]
        //         - ClusterSize: 0
        //           NbOfClusters: 0
        //           Decorations:
        //               - [ "AlienPlantSpike1", 0.3]
        //               - [ "AlienPlantMushroom2", 0.3]
        //               - [ "ConfettiMoss", 0.2]
        //               - [ "AlienPlantThorn2", 0.5]
        //               - [ "AridRock01", 0.015]
        //               - [ "AridRock02", 0.01]
        //               - [ "AridRock03", 0.015]
        //               - [ "GasEmitter1", 0.01]
        //               - [ "RealRock2", 0.02]
        //               - [ "RealRock4", 0.02]
        //   - Altitude: [ 40, 95 ]
        //     Slope: [ 0, 180 ]
        //     BiomeClusterData:
        //         - Name: "LavaPlains"
        //           Id: 1
        //           ClusterSize: 0
        //           NbOfClusters: 0
        //           Decorations:
        //               - [ "AridRock01", 0]
        //# Mountains
        //   - Altitude: [ 95, 150 ]
        //     Slope: [ 0, 20 ]
        //     BiomeClusterData:
        //         - Name: "Mountains"
        //           Id: 3
        //           ClusterSize: 0
        //           NbOfClusters: 0
        //           Decorations:
        //               - [ "AlienPlantThorn2", 0.7]
        //               - [ "GasEmitter2", 0.1]
        //               - [ "CrystalsPyramidBlue", 0.2]
        //   - Altitude: [ 95, 250 ]
        //     Slope: [ 0, 180 ]
        //     BiomeClusterData:
        //         - Name: "Mountains"
        //           Id: 3
        //           ClusterSize: 0
        //           NbOfClusters: 0
        //           Decorations:
        //               - [ "RealRock1", 0]
        //# Lava Area
        //   - Altitude: [ 0, 40 ]
        //     Slope: [ 0, 180 ]
        //     BiomeClusterData:
        //         - Name: "Lava"
        //           Id: 2
        //           ClusterSize: 0
        //           NbOfClusters: 0
        //           Decorations:
        //               - [ "AridRock01", 0]

        //TODO: normalize object
        public object POIs { get; set; }

        //### POIs
        //POIs:
        //    Random:
        //        - GroupName: GhostTierI
        //          CountMinMax: [ 4, 6 ]         # range of number of POIs of this group to distribute on planet
        //          DroneProb: 1.0                # probability that a POI is defended by drones
        //          DronesMinMax: [ 1, 2 ]        # range of number of drones that defend POI
        //          ReserveCount: 3
        //          TroopTransport: True          # if troop transport will be sent

        //        - GroupName: CrashedTitan
        //          CountMinMax: [ 1, 1 ]
        //          DroneProb: 1.0
        //          DronesMinMax: [ 1, 2 ]
        //          ReserveCount: 4
        //          TroopTransport: False

        //### Drones
        //DroneBaseSetup:
        //# PresetStyle:
        //# -> 0 = no drone attack base,
        //#    1 = day + 2 triggers,
        //#    2 = night + 2 triggers,
        //#    3 = at once + 2 triggers,
        //#    4 = night + turret trigger
        //    Random:
        //        - GroupName: DroneBaseAestus
        //          DronesMinMax: [ 4, 5 ]        # range of number of drones that defend drone base
        //          ReserveCount: 6               # number of drones that will be replaced when defending drones got killed
        //          DroneProb: 1.0                # probability that drones will defend drone base
        //          Difficulty: 6                 # 0..4 -> 0 = no drone attack base ... 4 = max difficulty level (5, 6, 7 = low, medium, high difficulty but with infinite drone waves)
        //          PresetStyle: 3                # 0..4 -> see comment above
        //          # BaseAttack: DroneSmallAttackBase
        //          Stock:
        //              - Name: DroneSmallFast01Plasma
        //                Amount: 20
        //                Extra: 0

        //              - Name: DroneLargeSlow01Plasma
        //                Amount: 20
        //                Extra: 0

        //              - Name: EnemyDroneV2Minigun
        //                Amount: 30
        //                Extra: 0

        //              - Name: DroneLargeSlow02Cannon
        //                Amount: 20
        //                Extra: 0

        //              - Name: DroneLargeSlow01Plasma   # Base attack drones
        //                Amount: 60
        //                Extra: 1

        //              - Name: EnemyDroneV2Plasma       # Base attack drones
        //                Amount: 20
        //                Extra: 1

        //              - Name: DroneTroopsTransport
        //                Amount: 1
        //                Extra: 2

        //              - Name: ZiraxMale
        //                Amount: 100
        //                Extra: 3

        //              - Name: Crawler
        //                Amount: 50
        //                Extra: 3

        //              - Name: TotalHorror
        //                Amount: 50
        //                Extra: 3

        //DroneSpawning:
        //    Random:
        //        - DronesMinMax: [ 5, 10 ]
        //          CenterX: -2500
        //          Radius: 1500

        //        - DronesMinMax: [ 5, 10 ]
        //          CenterX: 2500
        //          Radius: 1500

        //### Creatures
        //CreatureSpawning:
        //    - Biome: LavaPlains
        //      Entities:
        //        - Name: Overseers
        //          Period: Day              #  Night / Day / Always
        //          Amount: 2
        //          Delay: 0
        //        - Name: TotalHorrors
        //          Period: Night
        //          Amount: 2
        //          Delay: 0

        //    - Biome: Mountains
        //      Entities:
        //        - Name: AlienBugs02
        //          Period: Always
        //          Amount: 1
        //          Delay: 0

        //    - Biome: Lava
        //      Entities:
        //        - Name: TotalHorrors
        //          Period: Always
        //          Amount: 3
        //          Delay: 0
    }
}