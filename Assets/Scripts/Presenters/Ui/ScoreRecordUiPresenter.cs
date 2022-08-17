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
            _scoreModel.RecordScoreChanged -= OnRecordScoreChanged;
        }

        public void Enable()
        {
            _scoreModel.RecordScoreChanged += OnRecordScoreChanged;
            _scoreRecordView.SetScoreRecord(_scoreModel.RecordScore);
        }

        private void OnRecordScoreChanged(int scoreRecord)
        {
            _scoreRecordView.SetScoreRecord(scoreRecord);
        }
    }
}
