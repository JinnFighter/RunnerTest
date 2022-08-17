using System;

namespace Models
{
    public class GameStateModel
    {
        private bool _isActive = true;

        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    IsActiveChanged?.Invoke(_isActive);
                }
            }
        }

        public event Action<bool> IsActiveChanged;
    }
}
