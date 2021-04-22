namespace Asteroids
{
    internal class MovingShipState : ShipState
    {
        internal override void Handle(Context context)
        {
            context.ShipState = new IdleShipState();
        }
    }
}