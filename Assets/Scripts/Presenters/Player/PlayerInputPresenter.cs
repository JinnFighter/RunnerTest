using Models;
using UnityEngine.InputSystem;

namespace Presenters.Player
{
    public class PlayerInputPresenter : IPresenter
    {
        private readonly PlayerModel _playerModel;
        private readonly InputActions.PlayerActions _playerActions;

        public PlayerInputPresenter(PlayerModel playerModel, InputActions.PlayerActions playerActions)
        {
            _playerModel = playerModel;
            _playerActions = playerActions;
        }

        public void Disable()
        {
            _playerActions.MoveLeft.performed -= OnMoveLeftPerformed;
            _playerActions.MoveRight.performed -= OnMoveRightPerformed;
        }

        public void Enable()
        {
            _playerActions.MoveLeft.performed += OnMoveLeftPerformed;
            _playerActions.MoveRight.performed += OnMoveRightPerformed;
        }

        private void OnMoveLeftPerformed(InputAction.CallbackContext obj)
        {
            switch (_playerModel.MoveDirection)
            {
                case MoveDirection.Middle:
                    _playerModel.MoveDirection = MoveDirection.Left;
                    break;
                case MoveDirection.Right:
                    _playerModel.MoveDirection = MoveDirection.Middle;
                    break;
                case MoveDirection.Left:
                default:
                    break;
            }
        }
        
        private void OnMoveRightPerformed(InputAction.CallbackContext obj)
        {
            switch (_playerModel.MoveDirection)
            {
                case MoveDirection.Middle:
                    _playerModel.MoveDirection = MoveDirection.Right;
                    break;
                case MoveDirection.Left:
                    _playerModel.MoveDirection = MoveDirection.Middle;
                    break;
                case MoveDirection.Right:
                default:
                    break;
            }
        }
    }
}
