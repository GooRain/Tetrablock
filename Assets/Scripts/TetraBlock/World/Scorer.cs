using System.Collections.Generic;
using System.Linq;
using Common.SharedValues;
using TetraBlock.World.Board;

namespace TetraBlock.World
{
    public class Scorer
    {
        private readonly IntValue intValue;

        public Scorer(IntValue intValue)
        {
            this.intValue = intValue;
        }

        public void ScoreDestroyedCells(IEnumerable<Cell> cells)
        {
            intValue.SetValue(intValue.GetValue() + cells.Count());
        }
    }
}