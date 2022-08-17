using System.Collections.Generic;

namespace Presenters
{
    public class CompositePresenter : IPresenter
    {
        private readonly List<IPresenter> _presenters;

        public CompositePresenter(List<IPresenter> presenters)
        {
            _presenters = presenters;
        }

        public void Disable()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Disable();
            }
        }

        public void Enable()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Enable();
            }
        }
    }
}
