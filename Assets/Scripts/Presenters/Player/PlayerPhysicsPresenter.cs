using Models;
using Views;

namespace Presenters.Player
{
    public class PlayerPhysicsPresenter : IPresenter
    {
        private readonly PlayerModel _playerModel;
        private readonly PlayerView _playerView;

        public PlayerPhysicsPresenter(PlayerModel playerModel, PlayerView playerView)
        {
            _playerModel = playerModel;
            _playerView = playerView;
        }

        public void Disable()
        {
            _playerModel.IsAliveChanged -= OnIsAliveChanged;
            if (_playerModel.IsAlive && _playerView != null)
            {
                _playerView.DisablePhysics();
            }
        }

        public void Enable()
        {
            _playerModel.IsAliveChanged += OnIsAliveChanged;
            OnIsAliveChanged(_playerModel.IsAlive);
        }

        private void OnIsAliveChanged(bool isAlive)
        {
            if (isAlive)
            {
                _playerView.EnablePhysics();
            }
            else
            {
                _playerView.DisablePhysics();
            }
        }
    }
}
