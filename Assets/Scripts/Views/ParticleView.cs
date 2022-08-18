using UnityEngine;

namespace Views
{
    public class ParticleView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        public void PlayParticlesAt(Vector3 position) => _particleSystem.Emit(new ParticleSystem.EmitParams
        {
            position = position
        }, 50);
    }
}
