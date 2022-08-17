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
            PlayerPrefs.SetInt("ScoreRecord", _scoreModel.RecordScore);
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
            }
            
            _gameStateModel.IsActiveChanged += OnIsActiveChanged;
        }

        private void OnIsActiveChanged(bool isActive)
        {
            if (!isActive)
            {
                PlayerPrefs.SetInt("ScoreRecord", _scoreModel.RecordScore);
            }
        }
    }
}
