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
                var verticalCells = new List<Cell>();

                for (var y = 0; y < size.y; y++)
                {
                    var position = center + new Vector3(x, y);
                    var cell = Instantiate(mapConfig.CellPrefab, position, Quaternion.identity,
                        polygon);

                    cell.Initialize(mapConfig, position);

                    _map[x, y] = cell;

                    verticalCells.Add(cell);

                    polygonCells.Add(cell);
                    polygonCellCounter++;

                    if (polygonCellCounter >= polygonSize)
                    {
                        _map.AddPolygon(new CellsPolygon(polygonCells));
                        polygonCells = new HashSet<Cell>();
                        polygon = new GameObject($"Polygon [{polygonCounter++}]").transform;
                        polygon.SetParent(transform);

                        polygonCellCounter = 0;
                    }
                }

                var verticalCheckZone = new CellsCheckZone(verticalCells);

                _map.AddCellZone(verticalCheckZone);
            }

            for (int y = 0; y < size.x; y++)
            {
                var horizontalCells = new List<Cell>();

                for (int x = 0; x < size.y; x++)
                {
                    horizontalCells.Add(_map[x, y]);
                }

                var horizontalCheckZone = new CellsCheckZone(horizontalCells);

                _map.AddCellZone(horizontalCheckZone);
            }

            var polygons = new List<CellsPolygon>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        polygons.Add(_map.GetPolygon(i * 9 + j + k * 3));
                    }

                    _map.AddCellZone(new CellsCheckZone(polygons));
                    polygons.Clear();
                }
            }
        }
    }
}