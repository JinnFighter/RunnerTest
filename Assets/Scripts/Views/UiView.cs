using UnityEngine;

namespace Views
{
    public class UiView : MonoBehaviour
    {
        [field: SerializeField] public ScoreView ScoreView { get; private set; }
        [field: SerializeField] public ScoreRecordView ScoreRecordView { get; private set; }
    }
}
