using System;
using System.Collections.Generic;

namespace TetraBlock.World.Board
{
    public class CellsCheckZone
    {
        private readonly List<Cell> _cells;
        private readonly int _cellsCount;

        public Action onCheck;

        public List<Cell> Cells => _cells;

        public CellsCheckZone(List<Cell> cells)
        {
            _cells = cells;
            _cellsCount = _cells.Count;

            foreach (var cell in Cells)
            {
                cell.onOccupy = Check;
            }
        }

        public CellsCheckZone(List<CellsPolygon> polygons)
        {
            _cells = new List<Cell>();

            foreach (var polygon in polygons)
            {
                _cells.AddRange(polygon.Cells);
            }

            _cellsCount = _cells.Count;

            foreach (var cell in Cells)
            {
                cell.onOccupy = Check;
            }
        }

        public bool IsOccupied()
        {
            for (var i = 0; i < _cellsCount; i++)
            {
                if (!_cells[i].IsOccupied)
                {
                    return false;
                }
            }

            return true;
        }

        public void Check()
        {
            onCheck?.Invoke();
        }
    }
}