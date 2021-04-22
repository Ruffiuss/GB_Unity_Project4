namespace Asteroids
{
    internal abstract class ShipState
    {
        internal abstract void Handle(Context context);
        internal abstract void Loop();
    }
}