using UnityEngine;

namespace Descriptions
{
    [CreateAssetMenu(fileName = "AudioDescription", menuName = "Descriptions/AudioDescription")]
    public class AudioDescription : ScriptableObject
    {
        [field: SerializeField] public AudioClip CoinPickUpClip { get; private set; }
    }
}
