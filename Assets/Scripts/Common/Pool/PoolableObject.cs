using UnityEngine;

namespace Common.Pool
{
    public abstract class PoolableObject : MonoBehaviour, IPoolable
    {
        public abstract void OnPush();
        public abstract void OnPull();
        public abstract void OnCreate();
    }
}