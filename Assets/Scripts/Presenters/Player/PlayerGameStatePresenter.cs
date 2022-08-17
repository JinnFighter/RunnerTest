using Models;

namespace Presenters.Player
{
    public class PlayerGameStatePresenter : IPresenter
    {
        private readonly PlayerModel _playerModel;
        private readonly GameStateModel _gameStateModel;

        public PlayerGameStatePresenter(PlayerModel playerModel, GameStateModel gameStateModel)
        {
            _playerModel = playerModel;
            _gameStateModel = gameStateModel;
        }

        public void Disable()
        {
            _playerModel.IsAliveChanged -= OnIsAliveChanged;
        }

        public void Enable()
        {
            _playerModel.IsAliveChanged += OnIsAliveChanged;
        }

        private void OnIsAliveChanged(bool isAlive)
        {
            _gameStateModel.IsActive = isAlive;
        }
    }
}
