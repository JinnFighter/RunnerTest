using Models;
using UnityEngine;
using Views;

namespace Presenters.Player
{
    public class PlayerCollisionPresenter : IPresenter
    {
        private readonly PlayerModel _playerModel;
        private readonly PlayerView _playerView;

        public PlayerCollisionPresenter(PlayerModel playerModel, PlayerView playerView)
        {
            _playerModel = playerModel;
            _playerView = playerView;
        }

        public void Disable()
        {
            _playerView.ColliderView.CollisionEnterEvent -= CollisionEnterEvent;
        }

        public void Enable()
        {
            _playerView.ColliderView.CollisionEnterEvent += CollisionEnterEvent;
        }

        private void CollisionEnterEvent(Collision collision)
        {
            var gameObject = collision.gameObject;
            if (gameObject.CompareTag("Obstacle") || gameObject.CompareTag("Finish"))
            {
                _playerModel.IsAlive = false;
            }
            else if (gameObject.CompareTag("Coin"))
            {
                _playerModel.PickUpCoin();
            }
        }
    }
}
