using System.Collections.Generic;
using Helpers;
using Models;
using UnityEngine;
using Views;
using Zenject;

namespace Presenters
{
    public class RoadBuilderPresenter : IPresenter
    {
        [Inject] private readonly RoadBuilderModel _roadBuilderModel;
        [Inject] private readonly RoadStartTileView _roadStartTileView;
        [Inject] private readonly IContent<RoadMiddleTileView> _middleTileContent;
        [Inject] private readonly IContent<RoadFinishTileView> _finishTileContent;
        [Inject] private readonly IContent<CoinView> _coinContent;
        [Inject] private readonly IContent<ObstacleView> _obstacleContent;
        [Inject] private readonly ChanceChecker _chanceChecker;

        private readonly Queue<RoadTileView> _views = new();

        public void Disable()
        {
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

            for (var i = 0; i < _roadBuilderModel.RoadLength; i++)
            {
                var view = i < _roadBuilderModel.RoadLength - 1
                    ? SpawnMiddleTileView()
                    : SpawnFinishTileView();
                
                _views.Enqueue(view);
                
                _roadBuilderModel.SpawnPosition = view.transform.position + Vector3.forward * view.TileLength;
            }
        }

        private RoadTileView SpawnMiddleTileView()
        {
            var tileView = _middleTileContent.Generate(_roadBuilderModel.SpawnPosition);
            foreach (var spawnPoint in tileView.SpawnPoints)
            {
                if (_chanceChecker.IsProc(_roadBuilderModel.CoinSpawnChance))
                {
                    _coinContent.Generate(spawnPoint.position);
                }
                else if (_chanceChecker.IsProc(_roadBuilderModel.ObstacleSpawnChance))
                {
                    _obstacleContent.Generate(spawnPoint.position);
                }
            }
            return tileView;
        }

        private RoadTileView SpawnFinishTileView()
        {
            return _finishTileContent.Generate(_roadBuilderModel.SpawnPosition);
        }
    }
}
