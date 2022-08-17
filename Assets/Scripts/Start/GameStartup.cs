using Containers;
using UnityEngine;
using Zenject;

namespace Start
{
    public class GameStartup : MonoBehaviour
    {
        [Inject] private PresenterContainer _presenterContainer;

        private void Start()
        {
            foreach (var presenter in _presenterContainer)
            {
                presenter.Enable();
            }
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
