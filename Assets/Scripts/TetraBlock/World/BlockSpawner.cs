using System;
using System.Collections.Generic;
using Common.Service;
using TetraBlock.Global;
using TetraBlock.World.Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TetraBlock.World
{
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> spawnTransforms;

        private readonly List<MovingBlock> _spawnedBlocks = new List<MovingBlock>();

        private List<MovingBlock> _movingBlockPrefabs;

        private void Awake()
        {
            var main = ServiceLocator.Current.Get<Main>();
            var gameConfig = main.GameConfig;

            _movingBlockPrefabs = new List<MovingBlock>(gameConfig.MovingBlockPrefabs);
        }

        public List<MovingBlock> Spawn()
        {
            _spawnedBlocks.Clear();

            foreach (var spawnTransform in spawnTransforms)
            {
                var random = Random.Range(0, _movingBlockPrefabs.Count);
                var spawnPosition = spawnTransform.position;
                var movingBlock = Instantiate(_movingBlockPrefabs[random], spawnPosition, Quaternion.identity);

                movingBlock.SetStartPosition(spawnPosition);

                _spawnedBlocks.Add(movingBlock);
            }

            return _spawnedBlocks;
        }
    }
}