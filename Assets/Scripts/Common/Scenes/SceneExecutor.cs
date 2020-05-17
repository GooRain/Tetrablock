using UnityEngine;

namespace Common.Scenes
{
    public class SceneExecutor : SceneBehaviour
    {
        [SerializeField] private SceneBehaviour[] sceneBehaviours = default;

        private void Start()
        {
            Execute();
        }

        public override void Execute()
        {
            var length = sceneBehaviours.Length;
            for (var i = 0; i < length ; i++)
            {
                sceneBehaviours[i].Execute();
            }
        }
    }
}