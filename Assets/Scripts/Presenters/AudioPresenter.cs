using Descriptions;
using Models;
using Views;
using Zenject;

namespace Presenters
{
    public class AudioPresenter : IPresenter
    {
        [Inject] private readonly PlayerModel _playerModel;
        [Inject] private readonly AudioDescription _audioDescription;
        [Inject] private readonly AudioView _audioView;
        
        public void Disable()
        {
            _playerModel.CoinPickedUp -= OnCoinPickedUp;
        }

        public void Enable()
        {
            _playerModel.CoinPickedUp += OnCoinPickedUp;
        }

        private void OnCoinPickedUp()
        {
            _audioView.PlaySound(_audioDescription.CoinPickUpClip);
        }
    }
}
