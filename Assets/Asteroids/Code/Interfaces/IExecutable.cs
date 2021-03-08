namespace Asteroids
{
    internal interface IExecutable : IController
    {
        void Execute(float deltaTime);
    }
}