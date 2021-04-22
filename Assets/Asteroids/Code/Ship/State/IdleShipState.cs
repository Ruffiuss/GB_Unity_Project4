namespace Asteroids
{
    internal sealed class IdleShipState : ShipState
    {
        internal override void Handle(Context context)
        {
            context.ShipState = new MovingShipState();
        }
    }
}