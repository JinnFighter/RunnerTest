using Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views;
using Zenject;

namespace Presenters.Ui
{
    public class GameOverViewPresenter : IPresenter
    {
        [Inject] private readonly GameStateModel _gameStateModel;
        [Inject] private readonly ScoreModel _scoreModel;
        [Inject] private readonly GameOverView _gameOverView;
        
        public void Disable()
        {
            _gameStateModel.IsActiveChanged -= OnIsActiveChanged;
            if (!_gameStateModel.IsActive)
            {
                DisableWindow();
            }
        }

        public void Enable()
        {
            _gameStateModel.IsActiveChanged += OnIsActiveChanged;
            if (!_gameStateModel.IsActive)
            {
                EnableWindow();
            }
        }

        private void EnableWindow()
        {
            _gameOverView.GameObject.transform.localScale = Vector3.zero;
            LeanTween.scale(_gameOverView.GameObject, Vector3.one, 0.8f);
            _gameOverView.GameObject.SetActive(true);
            _gameOverView.SetScore(_scoreModel.Score);
            if (_scoreModel.Score > _scoreModel.RecordScore)
            {
                _gameOverView.NewRecordGameObject.SetActive(true);
            }
            _gameOverView.RestartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnRestartButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void DisableWindow()
        {
            if (_gameOverView != null)
            {
                LeanTween.scale(_gameOverView.GameObject, Vector3.zero, 0.8f);
                _gameOverView.NewRecordGameObject.SetActive(false);
                _gameOverView.RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
                _gameOverView.gameObject.SetActive(false);
            }
        }

        private void OnIsActiveChanged(bool isActive)
        {
            if (isActive)
            {
                DisableWindow();
            }
            else
            {
                EnableWindow();
            }
        }
    }
}
