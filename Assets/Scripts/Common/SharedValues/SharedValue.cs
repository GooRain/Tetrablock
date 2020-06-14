using System.Collections.Generic;
using UnityEngine;

namespace Common.SharedValues
{
    public abstract class SharedValue<T> : ScriptableObject
    {
        [SerializeField] private T startValue;

        private T currentValue;

        private readonly List<IValueListener<T>> listeners = new List<IValueListener<T>>();

        private void Awake()
        {
            ResetValue();
        }

        public void SetValue(T newValue)
        {
            currentValue = newValue;
            RaiseListeners();
        }

        public void SetValueWithoutNotify(T newValue)
        {
            currentValue = newValue;
        }

        public T GetValue()
        {
            return currentValue;
        }

        public void ResetValue()
        {
            SetValue(startValue);
        }

        public void Register(IValueListener<T> valueListener)
        {
            listeners.Add(valueListener);
        }

        public void Unregister(IValueListener<T> valueListener)
        {
            listeners.Remove(valueListener);
        }

        private void RaiseListeners()
        {
            for (var i = listeners.Count - 1; i >= 0; --i)
            {
                listeners[i].Raise(currentValue);
            }
        }
    }
}