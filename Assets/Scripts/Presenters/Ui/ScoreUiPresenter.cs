using Models;
using Views;

namespace Presenters.Ui
{
    public class ScoreUiPresenter : IPresenter
    {
        private readonly ScoreModel _scoreModel;
        private readonly ScoreView _scoreView;

        public ScoreUiPresenter(ScoreModel scoreModel, ScoreView scoreView)
        {
            _scoreModel = scoreModel;
            _scoreView = scoreView;
        }

        public void Disable()
        {
            _scoreModel.ScoreChanged -= OnScoreChanged;
        }

        public void Enable()
        {
            _scoreModel.ScoreChanged += OnScoreChanged;
            _scoreView.SetScore(_scoreModel.Score);
        }

        private void OnScoreChanged(int score)
        {
            _scoreView.SetScore(score);
        }
    }
}
