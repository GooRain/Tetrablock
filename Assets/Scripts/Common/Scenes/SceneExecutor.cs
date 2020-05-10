using System;
using UnityEngine;

namespace Common.Scenes
{
    public class SceneExecutor : SceneBehaviour
    {
        [SerializeField] private SceneBehaviour[] sceneBehaviours;

        private void Awake()
        {
            Execute();
        }

        public override void Execute()
        {
            var length = sceneBehaviours.Length;
            for (int i = 0; i < length ; i++)
            {
                sceneBehaviours[i].Execute();
            }
        }
    }
}