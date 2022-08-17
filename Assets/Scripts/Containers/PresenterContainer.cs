using System.Collections;
using System.Collections.Generic;
using Presenters;

namespace Containers
{
    public class PresenterContainer : IEnumerable<IPresenter>
    {
        public IEnumerator<IPresenter> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
