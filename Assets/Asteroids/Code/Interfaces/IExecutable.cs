namespace Asteroids
{
    public interface IExecutable : IControllable
    {
        void Execute(float deltaTime);
    }
}