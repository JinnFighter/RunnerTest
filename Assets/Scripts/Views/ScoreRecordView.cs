using TMPro;
using UnityEngine;

namespace Views
{
    public class ScoreRecordView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreRecordText;

        public void SetScoreRecord(int scoreRecord) => _scoreRecordText.text = $"Record: {scoreRecord}";
    }
}
