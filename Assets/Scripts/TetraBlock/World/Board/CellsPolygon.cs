using System;
using System.Collections.Generic;
using Common.Extensions;
using Vector2 = UnityEngine.Vector2;

namespace TetraBlock.World.Board
{
    public class CellsPolygon : IPoint
    {
        public HashSet<Cell> Cells { get; }

        public Vector2 Position { get; set; }

        public CellsPolygon(HashSet<Cell> cells)
        {
            Cells = cells;

            Position = PointMethods.GetCentroid(Cells);
        }
    }
}