using UnityEngine;

namespace TetraBlock.Data
{
    [CreateAssetMenu(menuName = "TetraBlock/Data/Map Config Data")]
    public class MapConfig : ScriptableObject
    {
        [SerializeField] private Vector2Int size;
        [SerializeField] private Vector3 offset;
        [SerializeField] private GameObject cellPrefab;

        public Vector2Int Size => size;

        public Vector3 Offset => offset;

        public GameObject CellPrefab => cellPrefab;
    }
}