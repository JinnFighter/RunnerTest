using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Image _coinImage;

        private GameObject _coinImageGameObject;

        private void Start()
        {
            _coinImageGameObject = _coinImage.gameObject;
            LeanTween.rotateAroundLocal(_coinImageGameObject, Vector3.up, -360f, 3f).setLoopCount(0);
        }

        public void SetScore(int score) => _scoreText.text = $"{score}";

        private void OnDestroy()
        {
            LeanTween.pause(_coinImageGameObject);
        }
    }
}
