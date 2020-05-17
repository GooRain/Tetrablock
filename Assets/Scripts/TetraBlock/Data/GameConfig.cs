using Common.UnityExtensions;
using Rotary_Heart.SerializableDictionaryLite;
using TetraBlock.Data.Types;
using TetraBlock.Global.Scene;
using UnityEngine;

namespace TetraBlock.Data
{
    [CreateAssetMenu(menuName = "TetraBlock/Data/Game Config Data")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private MapConfig mapConfig = default;

        [SerializeField] private Color mainColor = default;

        [SerializeField] private float animatedScale = .75f;
        [SerializeField] private float animationDuration = .25f;

        [Space(20), Header("Scenes")]

        [SerializeField] private SceneContextTypeDictionary scenes = default;

        public MapConfig MapConfig => mapConfig;

        public SceneContextTypeDictionary Scenes => scenes;

        public float AnimatedScale => animatedScale;

        public float AnimationDuration => animationDuration;
    }
}