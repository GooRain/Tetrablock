namespace Common.Pool
{
    public interface IPool<T>
    {
        T Pull();
        void Push(T obj);

        void Create();
    }
}