namespace Common.SharedValues
{
    public interface IValueListener<in T>
    {
        void Raise(T value);
    }
}