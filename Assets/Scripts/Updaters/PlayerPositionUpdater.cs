using Models;
using UnityEngine;
using Views;

namespace Updaters
{
    public class PlayerPositionUpdater : IUpdater
    {
        private readonly PlayerModel _playerModel;
        private readonly PlayerView _playerView;

        public PlayerPositionUpdater(PlayerModel playerModel, PlayerView playerView)
        {
            _playerModel = playerModel;
            _playerView = playerView;
        }

        public void Update(float deltaTime)
        {
            _playerView.SetPosition(_playerView.Transform.position +
                                    (Vector3.forward * _playerModel.MoveSpeed * deltaTime));
            _playerModel.Position = _playerView.Transform.position;
        }
    }
}
