using Containers;
using UnityEngine;
using Views;
using Zenject;

namespace Start
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private ViewContainer _viewContainer;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private RoadStartTileView _roadStartTileView;
        [SerializeField] private RoadMiddleTileView _roadMiddleTileView;
        [SerializeField] private RoadFinishTileView _roadFinishTileView;
        [SerializeField] private UiView _uiView;
        [SerializeField] private GameOverView _gameOverView;
        
        public override void InstallBindings()
        {
            BindPrefabs();
            BindInput();
            BindScene();
            BindPresenters();
        }

        private void BindPrefabs()
        {
            Container.Bind<RoadMiddleTileView>().FromInstance(_roadMiddleTileView).AsSingle();
            Container.Bind<RoadFinishTileView>().FromInstance(_roadFinishTileView).AsSingle();
            Container.Bind<GameOverView>().FromInstance(_gameOverView).AsSingle();
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
            Container.Bind<PlayerView>().FromInstance(_playerView).AsSingle();
            Container.Bind<RoadStartTileView>().FromInstance(_roadStartTileView).AsSingle();
            Container.Bind<UiView>().FromInstance(_uiView).AsSingle();
        }
    }
}