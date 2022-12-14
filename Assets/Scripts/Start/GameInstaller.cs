using Containers;
using Descriptions;
using Helpers;
using Models;
using Presenters;
using Presenters.Player;
using Presenters.Score;
using Presenters.Ui;
using UnityEngine;
using Updaters;
using Views;
using Zenject;

namespace Start
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private ViewContainer _viewContainer;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private RoadStartTileView _roadStartTileView;
        [SerializeField] private UiView _uiView;
        [SerializeField] private GameOverView _gameOverView;
        [SerializeField] private AudioView _audioView;

        [SerializeField] private PrefabsContainer _prefabsContainer;
        [SerializeField] private DescriptionsContainer _descriptionsContainer;

        public override void InstallBindings()
        {
            BindDescriptions();
            BindModels();
            BindHelpers();
            BindPrefabs();
            BindInput();
            BindScene();
            BindPresenters();
        }

        private void BindHelpers()
        {
            Container.Bind<UpdaterRunner>().AsSingle();
            Container.Bind<ChanceChecker>().AsSingle();
        }

        private void BindModels()
        {
            Container.Bind<RoadBuilderModel>().AsSingle().NonLazy();
            Container.Bind<PlayerModel>().AsSingle().NonLazy();
            Container.Bind<GameStateModel>().AsSingle().NonLazy();
            Container.Bind<ScoreModel>().AsSingle().NonLazy();
        }

        private void BindDescriptions()
        {
            Container.Bind<RoadBuilderDescription>().FromScriptableObject(_descriptionsContainer.RoadBuilderDescription).AsSingle();
            Container.Bind<PlayerDescription>().FromScriptableObject(_descriptionsContainer.PlayerDescription).AsSingle();
            Container.Bind<AudioDescription>().FromScriptableObject(_descriptionsContainer.AudioDescription).AsSingle();
        }

        private void BindPrefabs()
        {
            Container.Bind<IContent<RoadMiddleTileView>>()
                .FromInstance(new InstantiatedContent<RoadMiddleTileView>(_prefabsContainer.RoadMiddleTileView)).AsSingle();
            Container.Bind<IContent<CoinView>>()
                .FromInstance(new InstantiatedContent<CoinView>(_prefabsContainer.CoinView)).AsSingle();
            Container.Bind<IContent<ObstacleView>>()
                .FromInstance(new InstantiatedContent<ObstacleView>(_prefabsContainer.ObstacleView)).AsSingle();
        }

        private void BindInput()
        {
            var inputActions = new InputActions();
            inputActions.Enable();
            Container.Bind<InputActions>().FromInstance(inputActions).AsSingle();
        }

        private void BindPresenters()
        {
            Container.Bind<ScorePresenter>().AsSingle();
            Container.Bind<RoadBuilderPresenter>().AsSingle();
            Container.Bind<PlayerPresenter>().AsSingle();
            Container.Bind<UiPresenter>().AsSingle();
            Container.Bind<GameOverViewPresenter>().AsSingle();
            Container.Bind<AudioPresenter>().AsSingle();
            
            Container.Bind<PresenterContainer>().AsSingle();
        }

        private void BindScene()
        {
            Container.Bind<ViewContainer>().FromInstance(_viewContainer).AsSingle();
            Container.Bind<PlayerView>().FromInstance(_playerView).AsSingle();
            Container.Bind<RoadStartTileView>().FromInstance(_roadStartTileView).AsSingle();
            Container.Bind<UiView>().FromInstance(_uiView).AsSingle();
            Container.Bind<GameOverView>().FromInstance(_gameOverView).AsSingle();
            Container.Bind<AudioView>().FromInstance(_audioView).AsSingle();
        }
    }
}