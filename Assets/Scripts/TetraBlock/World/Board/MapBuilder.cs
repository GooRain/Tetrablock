using System.Collections.Generic;
using Common.Scenes;
using Common.Service;
using TetraBlock.Data;
using TetraBlock.Global;
using TetraBlock.Global.Scene;
using UnityEngine;

namespace TetraBlock.World.Board
{
    public class MapBuilder : SceneBehaviour
    {
        private MapConfig mapConfig;

        private Map _map;

        public override void Execute()
        {
            var main = ServiceLocator.Current.Get<Main>();
            mapConfig = main.GameConfig.MapConfig;

            transform.position += mapConfig.Offset;

            Build(mapConfig.Size);

            if (main.TryGetCurrentContext(out GameContext gameContext))
            {
                gameContext.SetMap(_map);
            }
        }

        private void Build(Vector2Int size)
        {
            _map = new Map(mapConfig);

            var mapTransform = transform;
            var center = mapTransform.position;
            var polygonCounter = 0;
            var polygonSize = mapConfig.PolygonSize;
            var polygonCellCounter = 0;
            var polygonCells = new HashSet<Cell>();
            var polygon = new GameObject($"Polygon [{polygonCounter++}]").transform;
            polygon.SetParent(mapTransform);

            for (var x = 0; x < size.x; x++)
            {
                for (var y = 0; y < size.y; y++)
                {
                    var position = center + new Vector3(x, y);
                    var cell = Instantiate(mapConfig.CellPrefab, position, Quaternion.identity,
                        polygon);

                    cell.Initialize(mapConfig, position);

                    polygonCells.Add(cell);
                    polygonCellCounter++;

                    if (polygonCellCounter >= polygonSize)
                    {
                        _map.Add(new CellsPolygon(polygonCells));
                        polygonCells = new HashSet<Cell>();
                        polygon = new GameObject($"Polygon [{polygonCounter++}]").transform;
                        polygon.SetParent(transform);

                        polygonCellCounter = 0;
                    }
                }
            }
        }
    }
}