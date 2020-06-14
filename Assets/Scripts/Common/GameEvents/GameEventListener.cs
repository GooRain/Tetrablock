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

    public class GameEventListener<TGameEvent, TData, TUnityEvent> : MonoBehaviour, IEventListener<TData>
        where TGameEvent : GameEvent<TData>
        where TUnityEvent : UnityEvent<TData>
    {
        [SerializeField] private TGameEvent gameEvent;
        [SerializeField] private TUnityEvent responce;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }

        public void OnRaise(TData value)
        {
            responce.Invoke(value);
        }
    }
}