using Models;
using UnityEngine;
using Views;
using Zenject;

namespace Presenters
{
    public class ParticlePresenter : IPresenter
    {
        [Inject] private readonly PlayerModel _playerModel;
        [Inject] private readonly ParticleView _particleView;
        
        public void Disable()
        {
            _playerModel.CoinPickedUp -= OnCoinPickedUp;
            _playerModel.IsAliveChanged -= OnIsAliveChanged;
        }

        public void Enable()
        {
            _playerModel.CoinPickedUp += OnCoinPickedUp;
            _playerModel.IsAliveChanged += OnIsAliveChanged;
        }

        private void OnIsAliveChanged(bool isAlive)
        {
            if (!isAlive)
            {
                _particleView.PlayParticlesAt(_playerModel.Position);
            }
        }

        private void OnCoinPickedUp(Vector3 position)
        {
            _particleView.PlayParticlesAt(position);
        }
    }
}
