using Common.Scenes;
using TetraBlock.Data;
using UnityEngine;

namespace TetraBlock
{
    public class MapBuilder : SceneBehaviour
    {
        [SerializeField] private MapConfig mapConfig;

        private Map.Grid _grid;

        public override void Execute()
        {
            transform.position += mapConfig.Offset;

            Build(mapConfig.Size);
        }

        private void Build(Vector2Int size)
        {
            _grid = new Map.Grid(size.x, size.y);

            var center = transform.position;

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Instantiate(mapConfig.CellPrefab, center + new Vector3(x, y), Quaternion.identity, transform);
                }
            }
        }
    }
}