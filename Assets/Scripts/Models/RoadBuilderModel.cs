using System;
using System.Collections.Generic;
using Descriptions;
using UnityEngine;

namespace Models
{
    public class RoadBuilderModel
    {
        public RoadBuilderModel(RoadBuilderDescription roadBuilderDescription)
        {
            TileDespawnDistance = roadBuilderDescription.DespawnDistance;
            CoinSpawnChance = roadBuilderDescription.CoinSpawnChance;
            ObstacleSpawnChance = roadBuilderDescription.ObstacleSpawnChance;
            MaxTilesCount = roadBuilderDescription.MaxTilesCount;
        }
        public float TileDespawnDistance { get; }
        
        public Vector3 SpawnPosition { get; set; }
        
        public int CoinSpawnChance { get; }
        public int ObstacleSpawnChance { get; }

        public Queue<Vector3> TilePositions { get; } = new();
        public int MaxTilesCount { get; }

        public void SpawnTile(Vector3 position)
        {
            TilePositions.Enqueue(position);
            SpawnTileEvent?.Invoke(position);
        }

        public void DespawnTile()
        {
            if (TilePositions.Count > 0)
            {
                DespawnTileEvent?.Invoke(TilePositions.Dequeue());
            }
        }

        public event Action<Vector3> SpawnTileEvent;
        public event Action<Vector3> DespawnTileEvent;
    }
}
