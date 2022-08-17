using System;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(Collider))]
    public class ColliderView : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            CollisionEnterEvent?.Invoke(collision);
        }

        private void OnTriggerEnter(Collider other)
        {
            TriggerEnterEvent?.Invoke(other);
        }

        public event Action<Collision> CollisionEnterEvent;
        public event Action<Collider> TriggerEnterEvent;
    }
}
