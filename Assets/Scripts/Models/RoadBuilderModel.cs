using Descriptions;
using UnityEngine;

namespace Models
{
    public class RoadBuilderModel
    {
        public RoadBuilderModel(RoadBuilderDescription roadBuilderDescription)
        {
            RoadLength = roadBuilderDescription.RoadLength;
            TileDespawnDistance = roadBuilderDescription.DespawnDistance;
            CoinSpawnChance = roadBuilderDescription.CoinSpawnChance;
            ObstacleSpawnChance = roadBuilderDescription.ObstacleSpawnChance;
        }
        
        public int RoadLength { get; }
        public float TileDespawnDistance { get; }
        
        public Vector3 SpawnPosition { get; set; }
        
        public int CoinSpawnChance { get; }
        public int ObstacleSpawnChance { get; }
    }
}
