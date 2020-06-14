using System;
using System.Collections.Generic;
using Common.Service;
using TetraBlock.Data;
using TetraBlock.Global.Scene;
using TetraBlock.World.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TetraBlock.Global
{
    public partial class Main : MonoBehaviour, IService
    {
        [SerializeField] private GameConfig gameConfig = default;
        [SerializeField] private ParticlePool particlePool = default;

        private IContext _currentContext;

        private Dictionary<string, SceneContextType> scenes;

        public GameConfig GameConfig => gameConfig;

        public ParticlePool ParticlePool => particlePool;

        private void Initialize()
        {
            scenes = new Dictionary<string, SceneContextType>();

            var configScenes = gameConfig.Scenes;
            foreach (var configScene in configScenes)
            {
                scenes.Add(configScene.Value, configScene.Key);
            }

            ServiceLocator.Current.Register(this);

            SceneManager.sceneLoaded += OnSceneLoaded;

            SetSceneContext(SceneManager.GetActiveScene().name);
        }

        private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene,
            LoadSceneMode loadSceneMode)
        {
            SetSceneContext(scene.name);
        }

        private void SetSceneContext(string sceneName)
        {
            if (scenes.TryGetValue(sceneName, out var sceneContextType))
            {
                switch (sceneContextType)
                {
                    case SceneContextType.Menu:
                        _currentContext = new MenuContext();
                        break;
                    case SceneContextType.Game:
                        _currentContext = new GameContext();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public bool TryGetCurrentContext<T>(out T context) where T : IContext
        {
            if (_currentContext is T currentContext)
            {
                context = currentContext;
                return true;
            }

            context = default;
            return false;
        }

        private void OnDestroy()
        {
            ServiceLocator.Current.Unregister(this);
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    public partial class Main
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Run()
        {
            ServiceLocator.Initialize();

            var mainPrefab = Resources.Load<Main>("Prefabs/Main");
            var mainGameObject = Instantiate(mainPrefab);
            DontDestroyOnLoad(mainGameObject);

            mainGameObject.Initialize();
        }
    }
}