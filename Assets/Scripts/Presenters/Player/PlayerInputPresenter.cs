using Models;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Presenters.Player
{
    public class PlayerInputPresenter : IPresenter
    {
        private readonly PlayerModel _playerModel;
        private readonly InputActions _inputActions;

        public PlayerInputPresenter(PlayerModel playerModel, InputActions inputActions)
        {
            _playerModel = playerModel;
            _inputActions = inputActions;
        }

        public void Disable()
        {
            _inputActions.Player.MouseDelta.performed -= OnMouseDeltaPerformed;
        }

        public void Enable()
        {
            _inputActions.Player.MouseDelta.performed += OnMouseDeltaPerformed;
        }

        private void OnMouseDeltaPerformed(InputAction.CallbackContext context)
        {
            var delta = context.ReadValue<Vector2>();
            if(delta.magnitude >= 1f)
            {
                if(Vector2.Angle(delta.normalized, Vector2.left) < 35f)
                {
                    _playerModel.StrafeDirection = Vector3.left;
                }
                else if(Vector2.Angle(delta.normalized, Vector2.right) < 35f)
                {
                    _playerModel.StrafeDirection = Vector3.right;
                }
                else
                {
                    _playerModel.StrafeDirection = Vector3.zero;
                }
            }
            else
            {
                _playerModel.StrafeDirection = Vector3.zero;
            }
        }
    }
}
