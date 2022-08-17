using UnityEngine;

namespace Views
{
    public class RoadMiddleTileView : RoadTileView
    {
        [field: SerializeField] public Transform[] SpawnPoints { get; private set; }
    }
}
