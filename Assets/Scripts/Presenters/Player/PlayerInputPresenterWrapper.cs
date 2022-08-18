using Models;

namespace Presenters.Player
{
    public class PlayerInputPresenterWrapper : IPresenter
    {
        private readonly PlayerModel _playerModel;
        private readonly IPresenter _presenter;
        
        public PlayerInputPresenterWrapper(PlayerModel playerModel, IPresenter presenter)
        {
            _playerModel = playerModel;
            _presenter = presenter;
        }

        public void Disable()
        {
            _playerModel.IsAliveChanged -= OnIsAliveChanged;
            if (_playerModel.IsAlive)
            {
                _presenter.Disable();
            }
        }

        public void Enable()
        {
            _playerModel.IsAliveChanged += OnIsAliveChanged;
            if (_playerModel.IsAlive)
            {
                _presenter.Enable();
            }
        }

        private void OnIsAliveChanged(bool isAlive)
        {
            if (isAlive)
            {
                _presenter.Enable();
            }
            else
            {
                _presenter.Disable();
            }
        }
    }
}
