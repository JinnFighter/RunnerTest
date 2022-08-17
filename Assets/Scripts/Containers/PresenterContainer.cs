using System.Collections;
using System.Collections.Generic;
using Presenters;
using Zenject;

namespace Containers
{
    public class PresenterContainer : IEnumerable<IPresenter>
    {
        [Inject] private readonly RoadBuilderPresenter _roadBuilderPresenter;
        
        public IEnumerator<IPresenter> GetEnumerator()
        {
            yield return _roadBuilderPresenter;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
