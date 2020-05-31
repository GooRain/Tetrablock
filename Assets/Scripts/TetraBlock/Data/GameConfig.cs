using System.Collections.Generic;
using TetraBlock.Data.Types;
using TetraBlock.World.Entities;
using UnityEngine;

namespace TetraBlock.Data
{
    [CreateAssetMenu(menuName = "TetraBlock/Data/Game Config Data")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private MapConfig mapConfig = default;

        [SerializeField] private Color mainColor = default;

        [SerializeField] private float defaultScale = .5f;
        [SerializeField] private float animatedScale = .75f;
        [SerializeField] private float animationDuration = .25f;
        [SerializeField] private Vector2 movingBlockTouchOffset = Vector2.zero;

        [Space(20), Header("Scenes")]

        [SerializeField] private SceneContextTypeDictionary scenes = default;

        [Space(20), Header("Prefabs")]

        [SerializeField] private List<MovingBlock> movingBlockPrefabs;

        public MapConfig MapConfig => mapConfig;

        public SceneContextTypeDictionary Scenes => scenes;

        public float DefaultScale => defaultScale;

        public float AnimatedScale => animatedScale;

        public float AnimationDuration => animationDuration;

        public Vector2 MovingBlockTouchOffset => movingBlockTouchOffset;

        public IReadOnlyList<MovingBlock> MovingBlockPrefabs => movingBlockPrefabs;
    }
}