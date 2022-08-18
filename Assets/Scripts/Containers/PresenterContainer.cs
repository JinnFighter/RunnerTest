using System.Collections;
using System.Collections.Generic;
using Presenters;
using Presenters.Player;
using Presenters.Score;
using Presenters.Ui;
using Zenject;

namespace Containers
{
    public class PresenterContainer : IEnumerable<IPresenter>
    {
        [Inject] private readonly ScorePresenter _scorePresenter;
        [Inject] private readonly RoadBuilderPresenter _roadBuilderPresenter;
        [Inject] private readonly PlayerPresenter _playerPresenter;
        [Inject] private readonly UiPresenter _uiPresenter;
        [Inject] private readonly GameOverViewPresenter _gameOverViewPresenter;

        public IEnumerator<IPresenter> GetEnumerator()
        {
            yield return _scorePresenter;
            yield return _roadBuilderPresenter;
            yield return _playerPresenter;
            yield return _uiPresenter;
            yield return _gameOverViewPresenter;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
