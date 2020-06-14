using System.Collections.Generic;
using Common.Scenes;
using Common.SharedValues;
using TetraBlock.World.Board;
using TetraBlock.World.Entities;
using UnityEngine;

namespace TetraBlock.World
{
    public class GameFlow : SceneBehaviour
    {
        [SerializeField] private BlockSpawner blockSpawner;
        [SerializeField] private IntValue scoreValue;

        private Scorer scorer;
        private HashSet<MovingBlock> movingBlocks;

        public override void Execute()
        {
            RespawnBlocks();

            scorer = new Scorer(scoreValue);
            scoreValue.ResetValue();
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

        public void OnCellsDestroyed(IEnumerable<Cell> cells)
        {
            scorer.ScoreDestroyedCells(cells);
        }
    }
}