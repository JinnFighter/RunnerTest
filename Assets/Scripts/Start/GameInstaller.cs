using Containers;
using UnityEngine;
using Views;
using Zenject;

namespace Start
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private ViewContainer _viewContainer;
        [SerializeField] private UiView _uiView;
        
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
            Container.Bind<UiView>().FromInstance(_uiView).AsSingle();
        }
    }
}