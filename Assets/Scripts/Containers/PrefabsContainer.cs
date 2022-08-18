using UnityEngine;
using Views;

namespace Containers
{
    [CreateAssetMenu(fileName = "PrefabsContainer", menuName = "Containers/PrefabsContainer")]
    public class PrefabsContainer : ScriptableObject
    {
        [field: SerializeField] public CoinView CoinView { get; private set; }
        [field: SerializeField] public ObstacleView ObstacleView { get; private set; }
        [field: SerializeField] public RoadMiddleTileView RoadMiddleTileView { get; private set; }
    }
}
