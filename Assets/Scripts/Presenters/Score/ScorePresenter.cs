using Models;
using UnityEngine;
using Zenject;

namespace Presenters.Score
{
    public class ScorePresenter : IPresenter
    {
        [Inject] private readonly ScoreModel _scoreModel;
        [Inject] private readonly GameStateModel _gameStateModel;
        
        public void Disable()
        {
            _gameStateModel.IsActiveChanged -= OnIsActiveChanged;
            if (_scoreModel.Score > _scoreModel.RecordScore)
            {
                _scoreModel.RecordScore = _scoreModel.Score;
            }
            PlayerPrefs.SetInt("ScoreRecord", _scoreModel.RecordScore);
            PlayerPrefs.Save();
        }

        public void Enable()
        {
            if (PlayerPrefs.HasKey("ScoreRecord"))
            {
                _scoreModel.RecordScore = PlayerPrefs.GetInt("ScoreRecord");
            }
            else
            {
                PlayerPrefs.SetInt("ScoreRecord", _scoreModel.RecordScore);
                PlayerPrefs.Save();
            }
            
            _gameStateModel.IsActiveChanged += OnIsActiveChanged;
        }

        private void OnIsActiveChanged(bool isActive)
        {
            if (!isActive)
            {
                if (_scoreModel.Score > _scoreModel.RecordScore)
                {
                    PlayerPrefs.SetInt("ScoreRecord", _scoreModel.Score);
                    PlayerPrefs.Save();
                }
            }
        }
    }
}
