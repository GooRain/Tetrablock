using System.Collections.Generic;
using Common.Scenes;
using TetraBlock.World.Entities;
using UnityEngine;

namespace TetraBlock.World
{
    public class GameFlow : SceneBehaviour
    {
        [SerializeField] private BlockSpawner blockSpawner;

        private HashSet<MovingBlock> movingBlocks;

        public override void Execute()
        {
            RespawnBlocks();
        }

        private void RespawnBlocks()
        {
            movingBlocks = new HashSet<MovingBlock>(blockSpawner.Spawn());

            foreach (var movingBlock in movingBlocks)
            {
                movingBlock.onPlace = OnPlaceBlock;
            }
        }

        private void OnPlaceBlock(MovingBlock block)
        {
            block.onPlace = null;
            movingBlocks.Remove(block);

            if (movingBlocks.Count <= 0)
            {
                RespawnBlocks();
            }
        }
    }
}