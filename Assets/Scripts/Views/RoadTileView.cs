using UnityEngine;

namespace Views
{
    public abstract class RoadTileView : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        public float TileLength => _collider.bounds.size.z;
    }
}
