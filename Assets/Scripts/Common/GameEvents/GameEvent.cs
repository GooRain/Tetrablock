using System.Collections.Generic;
using UnityEngine;

namespace Common.GameEvents
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        private readonly List<IEventListener> gameEventListeners = new List<IEventListener>();

        public void RegisterListener(IEventListener eventListener)
        {
            if (!gameEventListeners.Contains(eventListener))
            {
                gameEventListeners.Add(eventListener);
            }
        }

        public void UnregisterListener(IEventListener eventListener)
        {
            if (gameEventListeners.Contains(eventListener))
            {
                gameEventListeners.Remove(eventListener);
            }
        }

        public void Raise()
        {
            for (var i = gameEventListeners.Count - 1; i >= 0; --i)
            {
                gameEventListeners[i].OnRaise();
            }
        }
    }
}