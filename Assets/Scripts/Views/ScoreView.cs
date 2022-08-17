using TMPro;
using UnityEngine;

namespace Views
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void SetScore(int score) => _scoreText.text = $"Score: {score}";
    }
}
