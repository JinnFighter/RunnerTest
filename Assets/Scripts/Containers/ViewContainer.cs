using UnityEngine;

namespace Containers
{
    public class ViewContainer : MonoBehaviour
    {
        [field: SerializeField] public Canvas UiCanvas { get; private set; }
        [field: SerializeField] public Canvas PopupCanvas { get; private set; }
    }
}
