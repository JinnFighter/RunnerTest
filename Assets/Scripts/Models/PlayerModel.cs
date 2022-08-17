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
        
        public float MoveSpeed;
        public float StrafeSpeed;
        public Vector3 StrafeDirection;

        public PlayerModel(PlayerDescription playerDescription)
        {
            MoveSpeed = playerDescription.MoveSpeed;
            StrafeSpeed = playerDescription.StrafeSpeed;
        }

        public event Action<bool> IsAliveChanged;
    }
}
