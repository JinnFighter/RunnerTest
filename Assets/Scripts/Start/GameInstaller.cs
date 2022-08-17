using Containers;
using UnityEngine;
using Zenject;

namespace Start
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private ViewContainer _viewContainer;
        
        public override void InstallBindings()
        {
            BindInput();
            BindScene();
            BindPresenters();
        }

        private void BindInput()
        {
            Container.Bind<InputActions>().AsSingle();
        }

        private void BindPresenters()
        {
            Container.Bind<PresenterContainer>().AsSingle();
        }

        private void BindScene()
        {
            Container.Bind<ViewContainer>().FromInstance(_viewContainer).AsSingle();
        }
    }
}