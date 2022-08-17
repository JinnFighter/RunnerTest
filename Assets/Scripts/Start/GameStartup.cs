using Containers;
using UnityEngine;
using Updaters;
using Zenject;

namespace Start
{
    public class GameStartup : MonoBehaviour
    {
        [Inject] private PresenterContainer _presenterContainer;
        [Inject] private UpdaterRunner _updaterRunner;

        private void Start()
        {
            foreach (var presenter in _presenterContainer)
            {
                presenter.Enable();
            }
        }

        private void Update()
        {
            _updaterRunner.Run(Time.deltaTime);
        }

        private void OnDestroy()
        {
            foreach (var presenter in _presenterContainer)
            {
                presenter.Disable();
            }
        }
    }
}
