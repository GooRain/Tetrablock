using System.Collections.Generic;

namespace Common.Service
{
    public class ServiceLocator
    {
        public static ServiceLocator Current { get; private set; }

        private readonly Dictionary<string, IService> _services = new Dictionary<string, IService>();

        public static void Initialize()
        {
            Current = new ServiceLocator();
        }

        public T Get<T>() where T : IService
        {
            var key = typeof(T).Name;

            if (_services.ContainsKey(key))
            {
                return (T) _services[key];
            }

            UnityEngine.Debug.LogError($"{key} not registered with {GetType().Name}");
            throw new System.InvalidOperationException();
        }

        public void Register<T>(T service) where T : IService
        {
            var key = service.GetType().Name;

            if (_services.ContainsKey(key))
            {
                UnityEngine.Debug.LogError(
                    $"Attempted to register service of type {key} which is already registered with the {GetType().Name}.");
                return;
            }

            _services.Add(key, service);
        }

        public void Unregister<T>(T obj) where T : IService
        {
            var key = obj.GetType().Name;

            if (!_services.ContainsKey(key))
            {
                UnityEngine.Debug.LogError(
                    $"Attempted to unregister service of type {key} which is not registered with the {GetType().Name}.");
                return;
            }

            _services.Remove(key);
        }
    }
}