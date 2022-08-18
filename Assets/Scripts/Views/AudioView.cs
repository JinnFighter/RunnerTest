using UnityEngine;

namespace Views
{
    public class AudioView : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        public void PlaySound(AudioClip audioClip) => _audioSource.PlayOneShot(audioClip);
        public void StopPlaying() => _audioSource.Stop();
    }
}
