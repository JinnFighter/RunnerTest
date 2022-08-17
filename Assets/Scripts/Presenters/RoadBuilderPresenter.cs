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

        private readonly List<RoadTileView> _views = new();

        public void Disable()
        {
            foreach (var roadTileView in _views)
            {
                Object.Destroy(roadTileView.gameObject);
            }
            
            _views.Clear();
        }

        public void Enable()
        {
            _roadBuilderModel.SpawnPosition = _roadBuilderModel.SpawnPosition =
                _roadStartTileView.transform.position + Vector3.forward * _roadStartTileView.TileLength;

            for (var i = 0; i < _roadBuilderModel.RoadLength; i++)
            {
                RoadTileView view = i < _roadBuilderModel.RoadLength - 1
                    ? _middleTileContent.Generate(_roadBuilderModel.SpawnPosition)
                    : _finishTileContent.Generate(_roadBuilderModel.SpawnPosition);
                
                _views.Add(view);
                
                _roadBuilderModel.SpawnPosition = view.transform.position + Vector3.forward * view.TileLength;
            }
        }
    }
}
