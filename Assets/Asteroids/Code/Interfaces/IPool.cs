namespace Asteroids
{
    internal interface IPool<T>
    {
        void Push(T go);
        T Pop();
    }
}