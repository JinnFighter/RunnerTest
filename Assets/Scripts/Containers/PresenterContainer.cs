using System.Collections;
using System.Collections.Generic;
using Presenters;
using Presenters.Player;
using Presenters.Ui;
using Zenject;

namespace Containers
{
    public class PresenterContainer : IEnumerable<IPresenter>
    {
        [Inject] private readonly RoadBuilderPresenter _roadBuilderPresenter;
        [Inject] private readonly PlayerPresenter _playerPresenter;
        [Inject] private readonly UiPresenter _uiPresenter;
        
        public IEnumerator<IPresenter> GetEnumerator()
        {
            yield return _roadBuilderPresenter;
            yield return _playerPresenter;
            yield return _uiPresenter;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
