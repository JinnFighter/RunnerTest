using UnityEngine;

namespace Descriptions
{
    [CreateAssetMenu(fileName = "RoadBuilderDescription", menuName = "Descriptions/RoadBuilderDescription")]
    public class RoadBuilderDescription : ScriptableObject
    {
        [field: SerializeField] public float DespawnDistance { get; private set; } = 10f;
        [field: SerializeField] public int MaxTilesCount { get; private set; } = 3;
        [field: SerializeField] public int CoinSpawnChance { get; private set; } = 50;
        [field: SerializeField] public int ObstacleSpawnChance { get; private set; } = 30;
    }
}
