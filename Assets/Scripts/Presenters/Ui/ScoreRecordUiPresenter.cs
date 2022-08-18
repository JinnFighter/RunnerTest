using Models;
using Views;

namespace Presenters.Ui
{
    public class ScoreRecordUiPresenter : IPresenter
    {
        private readonly ScoreModel _scoreModel;

        public ScoreRecordUiPresenter(ScoreModel scoreModel, ScoreRecordView scoreRecordView)
        {
            _scoreModel = scoreModel;
            _scoreRecordView = scoreRecordView;
        }

        private readonly ScoreRecordView _scoreRecordView;
        
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
