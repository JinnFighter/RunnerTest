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
            _playerView.ColliderView.TriggerEnterEvent -= TriggerEnterEvent;
        }

        public void Enable()
        {
            _playerView.ColliderView.CollisionEnterEvent += CollisionEnterEvent;
            _playerView.ColliderView.TriggerEnterEvent += TriggerEnterEvent;
        }

        private void TriggerEnterEvent(Collider collider)
        {
            var gameObject = collider.gameObject;
            if (gameObject.CompareTag("Coin"))
            {
                _playerModel.PickUpCoin(gameObject.transform.position);
                Object.Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Finish"))
            {
                _playerModel.IsAlive = false;
            }
        }

        private void CollisionEnterEvent(Collision collision)
        {
            var gameObject = collision.gameObject;
            if (gameObject.CompareTag("Obstacle"))
            {
                _playerModel.IsAlive = false;
            }
        }
    }
}
