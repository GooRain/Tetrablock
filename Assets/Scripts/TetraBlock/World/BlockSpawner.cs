using System.Collections.Generic;
using TetraBlock.World.Entities;
using UnityEngine;

namespace TetraBlock.World
{
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField] private List<MovingBlock> movingBlockPrefabs;
        [SerializeField] private List<Transform> spawnTransforms;

        public List<MovingBlock> Spawn()
        {
            var movingBlocks = new List<MovingBlock>();

            foreach (var spawnTransform in spawnTransforms)
            {
                var random = Random.Range(0, movingBlockPrefabs.Count);
                var spawnPosition = spawnTransform.position;
                var movingBlock = Instantiate(movingBlockPrefabs[random], spawnPosition, Quaternion.identity);

                movingBlock.SetStartPosition(spawnPosition);

                movingBlocks.Add(movingBlock);
            }

            return movingBlocks;
        }
    }
}