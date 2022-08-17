using UnityEngine;

namespace Views
{
    public class RoadFinishTileView : RoadTileView
    {
        [field: SerializeField] public ColliderView ColliderView { get; private set; }
    }
}
