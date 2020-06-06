namespace Common.Pool
{
    public interface IPoolable
    {
        void OnPush();
        void OnPull();
        void OnCreate();
    }
}