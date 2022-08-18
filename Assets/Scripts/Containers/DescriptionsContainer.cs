using Descriptions;
using UnityEngine;

namespace Containers
{
    [CreateAssetMenu(fileName = "DescriptionsContainer", menuName = "Containers/DescriptionsContainer")]
    public class DescriptionsContainer : ScriptableObject
    {
        [field: SerializeField] public PlayerDescription PlayerDescription { get; private set; }
        [field: SerializeField] public RoadBuilderDescription RoadBuilderDescription { get; private set; }
        [field: SerializeField] public AudioDescription AudioDescription { get; private set; }
    }
}
