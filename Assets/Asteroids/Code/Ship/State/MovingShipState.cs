namespace Asteroids
{
    internal class MovingShipState : ShipState
    {
        internal override void Handle(Context context)
        {
            context.ShipState = new IdleShipState();
        }

        internal override void Loop()
        {
            System.Console.WriteLine("current state : moving");
        }
    }
}