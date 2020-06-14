using System.Collections.Generic;
using Common.Extensions;
using TetraBlock.Data;
using TetraBlock.GameEvents;
using UnityEngine;

namespace TetraBlock.World.Board
{
    public class Map
    {
        private readonly MapConfig _mapConfig;

        private readonly List<CellsPolygon> _cellPolygons;
        private readonly List<CellsCheckZone> _checkZones;

        private readonly Cell[,] _cellsGrid;

        private readonly CellsGameEvent _onClearCellsGameEvent;

        public Cell this[int x, int y]
        {
            get => _cellsGrid[x, y];
            set => _cellsGrid[x, y] = value;
        }

        public Map(MapConfig mapConfig)
        {
            _mapConfig = mapConfig;

            _cellPolygons = new List<CellsPolygon>();
            _checkZones = new List<CellsCheckZone>();

            _cellsGrid = new Cell[mapConfig.Size.x, mapConfig.Size.y];

            _onClearCellsGameEvent = _mapConfig.OnClearCellsGameEvent;
        }

        public void AddPolygon(CellsPolygon cellPolygon)
        {
            _cellPolygons.Add(cellPolygon);
        }

        public void AddCellZone(CellsCheckZone cellsCheckZone)
        {
            cellsCheckZone.onCheck = CheckCellZones;

            _checkZones.Add(cellsCheckZone);
        }

        public bool TryGetClosest(Vector2 point, out Cell cell)
        {
            var closestPolygon = PointMethods.FindClosestPoint(point, _cellPolygons);

            // Debug.Log($"Closest Polygon: {closestPolygon.Position}");

            return PointMethods.TryToFindClosestPoint(point, closestPolygon.Cells, _mapConfig.MaxDistanceToCell,
                out cell);
        }

        public void CheckCellZones()
        {
            var cells = new HashSet<Cell>();
            for (int zoneIndex = 0; zoneIndex < _checkZones.Count; zoneIndex++)
            {
                if (_checkZones[zoneIndex].IsOccupied())
                {
                    var markedCells = _checkZones[zoneIndex].Cells;
                    for (int markedIndex = 0; markedIndex < markedCells.Count; markedIndex++)
                    {
                        cells.Add(markedCells[markedIndex]);
                    }
                }
            }

            foreach (var cell in cells)
            {
                cell.Clear();
            }

            if (cells.Count > 0 && _onClearCellsGameEvent)
            {
                _onClearCellsGameEvent.Raise(cells);
            }
        }

        public CellsPolygon GetPolygon(int index)
        {
            return _cellPolygons[index];
        }
    }
}