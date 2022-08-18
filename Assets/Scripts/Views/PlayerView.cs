using UnityEngine;

namespace Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [field: SerializeField] public ColliderView ColliderView { get; private set; }

        private Transform _transform;
        public Transform Transform
        {
            get
            {
                if (_transform == null)
                {
                    _transform = transform;
                }
                
                return _transform;
            }
        }

        public void SetPosition(Vector3 position)
        {
            _rigidbody.MovePosition(position);
        }

        public void EnablePhysics()
        {
            _rigidbody.isKinematic = false;
        }

        public void DisablePhysics()
        {
            _rigidbody.isKinematic = true;
        }
    }
}
