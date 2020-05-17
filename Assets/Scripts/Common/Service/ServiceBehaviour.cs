namespace Common.Service
{
    public abstract class ServiceBehaviour : IService
    {
        protected virtual void Awake()
        {
            ServiceLocator.Current.Register(this);
        }

        protected virtual void OnDestroy()
        {
            ServiceLocator.Current.Unregister(this);
        }
    }
}