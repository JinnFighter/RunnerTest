using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        
        [field: SerializeField] public Button RestartButton { get; private set; }
        [field: SerializeField] public GameObject NewRecordGameObject { get; private set; }
        
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

        public void SetScore(int score) => _scoreText.text = $"{score}";
    }
}
