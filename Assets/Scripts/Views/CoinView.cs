using UnityEngine;

namespace Views
{
    public class CoinView : MonoBehaviour
    {
        private GameObject _gameObject;

        public GameObject GameObject
        {
            get
            {
                if (_gameObject == null)
                {
                    _gameObject = gameObject;
                }
                
                return _gameObject;
            }
        }
        private void Start()
        {
            LeanTween.rotateAroundLocal(GameObject, Vector3.up, 360f, 3f).setLoopCount(0);
        }

        private void OnDestroy()
        {
            LeanTween.pause(GameObject);
        }
    }
}
