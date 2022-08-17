using System.Collections.Generic;
using Models;
using Views;
using Zenject;

namespace Presenters.Ui
{
    public class UiPresenter : IPresenter
    {
        [Inject] private ScoreModel _scoreModel;
        [Inject] private UiView _uiView;
        
        private IPresenter _presenter;
        
        public void Disable()
        {
            _presenter.Disable();
        }

        public void Enable()
        {
            _presenter = new CompositePresenter(new List<IPresenter>
            {
                new ScoreUiPresenter(_scoreModel, _uiView.ScoreView),
                new ScoreRecordUiPresenter(_scoreModel, _uiView.ScoreRecordView),
            });
            _presenter.Enable();
        }
    }
}
