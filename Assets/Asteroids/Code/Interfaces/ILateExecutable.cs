namespace Asteroids
{
    internal interface ILateExecutable : IController
    {
        void LateExecute(float deltaTime);
    }
}