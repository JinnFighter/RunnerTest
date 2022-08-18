using Models;
using Views;

namespace Presenters.Ui
{
    public class ScoreRecordUiPresenter : IPresenter
    {
        private readonly ScoreModel _scoreModel;
        private readonly ScoreRecordView _scoreRecordView;

        public ScoreRecordUiPresenter(ScoreModel scoreModel, ScoreRecordView scoreRecordView)
        {
            _scoreModel = scoreModel;
            _scoreRecordView = scoreRecordView;
        }

        public void Disable()
        {
            _scoreModel.ScoreChanged -= OnScoreChanged;
        }

        public void Enable()
        {
            _scoreModel.ScoreChanged += OnScoreChanged;
            _scoreRecordView.SetScoreRecord(_scoreModel.RecordScore);
        }

        private void OnScoreChanged(int score)
        {
            if (score > _scoreModel.RecordScore)
            {
                _scoreRecordView.SetScoreRecord(score);
            }
        }
    }
}
