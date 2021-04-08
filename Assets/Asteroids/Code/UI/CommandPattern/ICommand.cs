namespace Asteroids
{
    internal interface ICommand
    {
        bool Successed { get; }
        bool Perform();
        void Undo();
    }
}