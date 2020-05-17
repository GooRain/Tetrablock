using System.Collections.Generic;
using UnityEngine;

namespace Common.Extensions
{
    public static class PointMethods
    {
        public static T FindClosestPoint<T>(Vector2 originPoint, IEnumerable<T> points) where T : IPoint
        {
            var closestDistance = float.MaxValue;

            T closestPoint = default;

            foreach (var point in points)
            {
                var distance = Vector2.Distance(point.Position, originPoint);

                // Debug.Log($"Distance {distance} : {point.Position} , {originPoint}");

                if (distance < closestDistance)
                {
                    closestPoint = point;
                    closestDistance = distance;
                }
            }

            return closestPoint;
        }

        public static bool TryToFindClosestPoint<T>(Vector2 originPoint, IEnumerable<T> points, float
            maxDistance, out T resultPoint) where T : IPoint
        {
            var closestDistance = float.MaxValue;

            resultPoint = default;

            foreach (var point in points)
            {
                var distance = Vector2.Distance(point.Position, originPoint);

                //Debug.Log($"Distance = {distance}, {distance} <= {maxDistance} && {closestDistance} > {distance}");

                if (distance < maxDistance && distance < closestDistance)
                {
                    resultPoint = point;
                    closestDistance = distance;
                }
            }

            return resultPoint != null;
        }

        public static Vector2 GetCentroid<T>(HashSet<T> points) where T : IPoint
        {
            var centroid = Vector2.zero;
            foreach (var point in points)
            {
                // Debug.Log($"Centroid + {point.Position} = {centroid}");

                centroid += point.Position;
            }

            centroid /= points.Count;

            return centroid;
        }
    }
}