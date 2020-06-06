using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Common.Pool
{
    public abstract class ObjectPool<T> : MonoBehaviour, IPool<T> where T : Object, IPoolable
    {
        [SerializeField] private T prefab;
        [SerializeField] private int initialSize;

        private Stack<T> poolStack;
        private Transform container;
        private int indexer;

        private void Awake()
        {
            container = new GameObject($"{GetType()}.Container").transform;
            container.SetParent(transform);
            poolStack = new Stack<T>();
        }

        private void Start()
        {
            for (var i = 0; i < initialSize; ++i)
            {
                Create();
            }
        }

        public T Pull()
        {
            if (poolStack.Count <= 0)
            {
                Create();
            }

            var pulledObj = poolStack.Pop();
            pulledObj.OnPull();

            return pulledObj;
        }

        public void Push(T obj)
        {
            poolStack.Push(obj);
            obj.OnPush();
        }

        public void Create()
        {
            var createdObj = Instantiate(prefab, container);
            createdObj.name = $"{createdObj.GetType().Name} [{indexer++:000}]";
            createdObj.OnCreate();
            poolStack.Push(createdObj);
        }
    }
}