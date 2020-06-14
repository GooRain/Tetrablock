using System.Collections.Generic;
using Common.GameEvents;
using TetraBlock.World.Board;
using UnityEngine.Events;

namespace TetraBlock.GameEvents
{
    public class CellsGameEventListener : GameEventListener<CellsGameEvent, IEnumerable<Cell>,
        CellsGameEventListener.CellsUnityEvent>
    {
        [System.Serializable]
        public class CellsUnityEvent : UnityEvent<IEnumerable<Cell>>
        {
        }
    }
}