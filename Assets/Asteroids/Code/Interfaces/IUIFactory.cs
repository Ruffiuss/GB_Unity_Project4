namespace Asteroids
{
    internal interface IUIFactory : IFactory
    {
        IController CreateUIFromData();
        UIController GetUIController { get; }
    }
}