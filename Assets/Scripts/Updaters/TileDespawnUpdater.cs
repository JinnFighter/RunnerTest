using Models;
using UnityEngine;

namespace Updaters
{
    public class TileDespawnUpdater : IUpdater
    {
        private readonly PlayerModel _playerModel;
        private readonly RoadBuilderModel _roadBuilderModel;

        public TileDespawnUpdater(PlayerModel playerModel, RoadBuilderModel roadBuilderModel)
        {
            _playerModel = playerModel;
            _roadBuilderModel = roadBuilderModel;
        }

        public void Update(float deltaTime)
        {
            if (_roadBuilderModel.TilePositions.Count > 0 &&
                Vector3.Distance(_playerModel.Position, _roadBuilderModel.TilePositions.Peek()) >=
                _roadBuilderModel.TileDespawnDistance)
            {
                _roadBuilderModel.DespawnTile();
            }
        }
    }
}
