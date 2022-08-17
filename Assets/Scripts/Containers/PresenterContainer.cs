using System.Collections;
using System.Collections.Generic;
using Presenters;
using Presenters.Player;
using Zenject;

namespace Containers
{
    public class PresenterContainer : IEnumerable<IPresenter>
    {
        [Inject] private readonly RoadBuilderPresenter _roadBuilderPresenter;
        [Inject] private readonly PlayerPresenter _playerPresenter;
        
        public IEnumerator<IPresenter> GetEnumerator()
        {
            yield return _roadBuilderPresenter;
            yield return _playerPresenter;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
