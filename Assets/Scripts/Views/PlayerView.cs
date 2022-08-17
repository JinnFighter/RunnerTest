using UnityEngine;

namespace Views
{
    public class PlayerView : MonoBehaviour
    {
        [field: SerializeField] public ColliderView ColliderView { get; private set; }
    }
}
