using System;
using Descriptions;
using UnityEngine;

namespace Models
{
    public class PlayerModel
    {
        private bool _isAlive = true;
        public bool IsAlive
        {
            get => _isAlive;
            set
            {
                if (_isAlive != value)
                {
                    _isAlive = value;
                    IsAliveChanged?.Invoke(_isAlive);
                }
            }
        }
        
        public readonly float MoveSpeed;
        public readonly float ShiftAmount;
        public Vector3 Position;

        private MoveDirection _moveDirection = MoveDirection.Middle;
        public MoveDirection MoveDirection
        {
            get => _moveDirection;
            set
            {
                if (_moveDirection != value)
                {
                    if (_moveDirection < value)
                    {
                        ShiftRightEvent?.Invoke();
                    }
                    else if (_moveDirection > value)
                    {
                        ShiftLeftEvent?.Invoke();
                    }
                    
                    _moveDirection = value;
                }
            }
        }

        public PlayerModel(PlayerDescription playerDescription)
        {
            MoveSpeed = playerDescription.MoveSpeed;
            ShiftAmount = playerDescription.ShiftAmount;
        }

        public void PickUpCoin()
        {
            CoinPickedUp?.Invoke();
        }

        public event Action<bool> IsAliveChanged;
        public event Action CoinPickedUp;
        public event Action ShiftLeftEvent;
        public event Action ShiftRightEvent;
    }

    public enum MoveDirection
    {
        Left,
        Middle,
        Right,
    }
}
