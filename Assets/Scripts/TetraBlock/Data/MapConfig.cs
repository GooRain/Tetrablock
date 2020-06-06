using Common.GameEvents;
using TetraBlock.World.Board;
using UnityEngine;

namespace TetraBlock.Data
{
    [CreateAssetMenu(menuName = "TetraBlock/Data/Map Config Data")]
    public class MapConfig : ScriptableObject
    {
        [SerializeField] private Vector2Int size = default;
        [SerializeField] private Vector3 offset = default;
        [SerializeField] private Cell cellPrefab = default;
        [SerializeField] private int polygonSize = 9;

        [Space(10)]

        [SerializeField] private Color cellDefaultColor = default;
        [SerializeField] private Color cellHighlightedColor = default;
        [SerializeField] private Color cellOccupiedColor = default;


        [Space(10)] [Header("Algorithm Parameters")]

        [SerializeField] private float maxDistanceToCell = default;

        [Space(10)] [Header("Game Events")]

        [SerializeField] private GameEvent onClearCellsGameEvent;

        public Vector2Int Size => size;

        public Vector3 Offset => offset;

        public Cell CellPrefab => cellPrefab;

        public int PolygonSize => polygonSize;

        public Color CellDefaultColor => cellDefaultColor;

        public Color CellHighlightedColor => cellHighlightedColor;

        public Color CellOccupiedColor => cellOccupiedColor;

        public float MaxDistanceToCell => maxDistanceToCell;

        public GameEvent OnClearCellsGameEvent => onClearCellsGameEvent;
    }
}