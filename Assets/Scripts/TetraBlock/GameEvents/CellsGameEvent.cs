using System.Collections.Generic;
using Common.GameEvents;
using TetraBlock.World.Board;
using UnityEngine;

namespace TetraBlock.GameEvents
{
    [CreateAssetMenu(menuName = "TetraBlock/GameEvent/CellsGameEvent")]
    public class CellsGameEvent : GameEvent<IEnumerable<Cell>>
    {

    }
}