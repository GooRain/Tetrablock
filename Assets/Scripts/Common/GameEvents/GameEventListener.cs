using UnityEngine;
using UnityEngine.Events;

namespace Common.GameEvents
{
    public class GameEventListener : MonoBehaviour, IEventListener
    {
        [SerializeField] private GameEvent gameEvent;
        [SerializeField] private UnityEvent responce;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }

        public void OnRaise()
        {
            responce.Invoke();
        }
    }
}