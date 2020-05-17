using System.Collections.Generic;
using Common.Extensions;
using TetraBlock.Data;
using UnityEngine;

namespace TetraBlock.World.Board
{
    public class Map
    {
        private readonly MapConfig _mapConfig;
        private readonly HashSet<CellsPolygon> _cellPolygons;

        public Map(MapConfig mapConfig)
        {
            _mapConfig = mapConfig;

            _cellPolygons = new HashSet<CellsPolygon>();
        }

        public void Add(CellsPolygon cellPolygon)
        {
            _cellPolygons.Add(cellPolygon);
        }

        public bool TryGetClosest(Vector2 point, out Cell cell)
        {
            var closestPolygon = PointMethods.FindClosestPoint(point, _cellPolygons);

            // Debug.Log($"Closest Polygon: {closestPolygon.Position}");

            return PointMethods.TryToFindClosestPoint(point, closestPolygon.Cells, _mapConfig.MaxDistanceToCell,
                out cell);
        }
    }
}