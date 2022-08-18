using Models;
using UnityEngine;
using Updaters;
using Views;

namespace Presenters.Player
{
    public class PlayerMovementPresenter : IPresenter
    {
        private readonly PlayerModel _playerModel;
        private readonly UpdaterRunner _updaterRunner;
        private readonly PlayerView _playerView;

        private readonly IUpdater _updater;

        public PlayerMovementPresenter(PlayerModel playerModel, UpdaterRunner updaterRunner, PlayerView playerView)
        {
            _playerModel = playerModel;
            _updaterRunner = updaterRunner;
            _playerView = playerView;

            _updater = new PlayerPositionUpdater(playerModel, playerView);
        }

        public void Disable()
        {
            _playerModel.IsAliveChanged -= OnIsAliveChanged;
            _playerModel.ShiftLeftEvent -= OnShiftLeftEvent;
            _playerModel.ShiftRightEvent -= OnShiftRightEvent;
            
            if (_playerModel.IsAlive)
            {
                RemoveUpdater();
            }
        }

        public void Enable()
        {
            _playerModel.IsAliveChanged += OnIsAliveChanged;
            _playerModel.ShiftLeftEvent += OnShiftLeftEvent;
            _playerModel.ShiftRightEvent += OnShiftRightEvent;
            
            if (_playerModel.IsAlive)
            {
                AddUpdater();
            }
        }

        private void OnShiftRightEvent()
        {
            _playerView.Transform.position += Vector3.right * _playerModel.ShiftAmount;
        }

        private void OnShiftLeftEvent()
        {
            _playerView.Transform.position += Vector3.left * _playerModel.ShiftAmount;
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
