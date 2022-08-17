using Models;
using Updaters;
using Views;

namespace Presenters.Player
{
    public class PlayerMovementPresenter : IPresenter
    {
        private readonly PlayerModel _playerModel;
        private readonly UpdaterRunner _updaterRunner;

        private readonly IUpdater _updater;

        public PlayerMovementPresenter(PlayerModel playerModel, UpdaterRunner updaterRunner, PlayerView playerView)
        {
            _playerModel = playerModel;
            _updaterRunner = updaterRunner;

            _updater = new PlayerPositionUpdater(playerModel, playerView);
        }

        public void Disable()
        {
            _playerModel.IsAliveChanged -= OnIsAliveChanged;
            if (_playerModel.IsAlive)
            {
                RemoveUpdater();
            }
        }

        public void Enable()
        {
            _playerModel.IsAliveChanged += OnIsAliveChanged;
            if (_playerModel.IsAlive)
            {
                AddUpdater();
            }
        }

        private void OnIsAliveChanged(bool isAlive)
        {
            if (isAlive)
            {
                AddUpdater();
            }
            else
            {
                RemoveUpdater();
            }
        }

        private void AddUpdater()
        {
            _updaterRunner.Add(_updater);
        }

        private void RemoveUpdater()
        {
            _updaterRunner.Remove(_updater);
        }
    }
}
