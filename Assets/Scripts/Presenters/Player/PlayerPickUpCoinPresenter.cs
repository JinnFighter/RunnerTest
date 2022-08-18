using Models;
using UnityEngine;

namespace Presenters.Player
{
    public class PlayerPickUpCoinPresenter : IPresenter
    {
        private readonly PlayerModel _playerModel;
        private readonly ScoreModel _scoreModel;

        public PlayerPickUpCoinPresenter(PlayerModel playerModel, ScoreModel scoreModel)
        {
            _playerModel = playerModel;
            _scoreModel = scoreModel;
        }

        public void Disable()
        {
            _playerModel.CoinPickedUp -= OnCoinPickedUp;
        }

        public void Enable()
        {
            _playerModel.CoinPickedUp += OnCoinPickedUp;
        }

        private void OnCoinPickedUp(Vector3 position)
        {
            _scoreModel.Score++;
        }
    }
}
