using System.Collections.Generic;
using Models;
using Updaters;
using Views;
using Zenject;

namespace Presenters.Player
{
    public class PlayerPresenter : IPresenter
    {
        [Inject] private readonly PlayerModel _playerModel;
        [Inject] private readonly UpdaterRunner _updaterRunner;
        [Inject] private readonly InputActions _inputActions;
        [Inject] private readonly PlayerView _playerView;

        private IPresenter _presenter;

        public void Disable()
        {
            _presenter.Disable();
        }

        public void Enable()
        {
            _presenter = new CompositePresenter
            (
                new List<IPresenter>
                {
                    new PlayerInputPresenter(_playerModel, _inputActions),
                    new PlayerMovementPresenter(_playerModel, _updaterRunner, _playerView),
                }
            );
            
            _presenter.Enable();
        }
    }
}
