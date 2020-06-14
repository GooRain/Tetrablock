namespace Common.GameEvents
{
    public interface IEventListener
    {
        void OnRaise();
    }

    public interface IEventListener<T>
    {
        void OnRaise(T value);
    }
}