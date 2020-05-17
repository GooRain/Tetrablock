using Common.Extensions;
using TetraBlock.Data;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace TetraBlock.World.Board
{
    public class Cell : MonoBehaviour, IPoint
    {
        [SerializeField] private SpriteRenderer spriteRenderer = default;

        private bool _isOccupied;

        private Transform _transform;

        private MapConfig _mapConfig;

        public bool IsOccupied => _isOccupied;

        public Transform Transform => _transform;

        public Vector2 Position { get; private set; }

        public void Initialize(MapConfig mapConfig, Vector3 position)
        {
            _mapConfig = mapConfig;

            _transform = transform;

            Position = position;
        }

        public void Unhighlight()
        {
            spriteRenderer.color = _mapConfig.CellDefaultColor;
        }

        public void Highlight()
        {
            spriteRenderer.color = _mapConfig.CellHighlightedColor;
        }

        public void Occupy()
        {
            spriteRenderer.color = _mapConfig.CellOccupiedColor;
            _isOccupied = true;
        }
    }
}