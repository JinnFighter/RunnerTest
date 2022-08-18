using System.Collections.Generic;
using Helpers;
using Models;
using UnityEngine;
using Updaters;
using Views;
using Zenject;

namespace Presenters
{
    public class RoadBuilderPresenter : IPresenter
    {
        [Inject] private readonly PlayerModel _playerModel;
        [Inject] private readonly RoadBuilderModel _roadBuilderModel;
        [Inject] private readonly RoadStartTileView _roadStartTileView;
        [Inject] private readonly IContent<RoadMiddleTileView> _middleTileContent;
        [Inject] private readonly IContent<CoinView> _coinContent;
        [Inject] private readonly IContent<ObstacleView> _obstacleContent;
        [Inject] private readonly ChanceChecker _chanceChecker;
        [Inject] private readonly UpdaterRunner _updaterRunner;

        private readonly Queue<RoadTileView> _views = new();

        private IUpdater _updater;

        public void Disable()
        {
            _updaterRunner.Remove(_updater);
            _roadBuilderModel.SpawnTileEvent -= OnSpawnTileEvent;
            _roadBuilderModel.DespawnTileEvent -= OnDespawnTileEvent;
            
            while (_views.Count > 0)
            {
                var view = _views.Dequeue();
                if (view != null)
                {
                    Object.Destroy(view.gameObject);
                }
            }
        }

        public void Enable()
        {
            _roadBuilderModel.SpawnPosition = _roadBuilderModel.SpawnPosition =
                _roadStartTileView.transform.position + Vector3.forward * _roadStartTileView.TileLength;

            _roadBuilderModel.SpawnTileEvent += OnSpawnTileEvent;
            _roadBuilderModel.DespawnTileEvent += OnDespawnTileEvent;

            for (var i = 0; i < _roadBuilderModel.MaxTilesCount; i++)
            {
                _roadBuilderModel.SpawnTile(_roadBuilderModel.SpawnPosition);
            }
            
            _updater = new TileDespawnUpdater(_playerModel, _roadBuilderModel);
            _updaterRunner.Add(_updater);
        }

        private void OnDespawnTileEvent(Vector3 position)
        {
            if (_views.Count > 0)
            {
                var view = _views.Dequeue();
                if (view != null)
                {
                    Object.Destroy(view.gameObject);
                }

                if (_roadBuilderModel.TilePositions.Count < _roadBuilderModel.MaxTilesCount)
                {
                    _roadBuilderModel.SpawnTile(_roadBuilderModel.SpawnPosition);
                }
            }
        }

        private void OnSpawnTileEvent(Vector3 spawnPosition)
        {
            var view = _middleTileContent.Generate(_roadBuilderModel.SpawnPosition);
            foreach (var spawnPoint in view.SpawnPoints)
            {
                if (_chanceChecker.IsProc(_roadBuilderModel.CoinSpawnChance))
                {
                    _coinContent.Generate(spawnPoint.position, view.transform);
                }
                else if (_chanceChecker.IsProc(_roadBuilderModel.ObstacleSpawnChance))
                {
                    _obstacleContent.Generate(spawnPoint.position, view.transform);
                }
            }
            
            _views.Enqueue(view);
            _roadBuilderModel.SpawnPosition = view.transform.position + Vector3.forward * view.TileLength;
        }
    }
}
