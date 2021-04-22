namespace Asteroids
{
    internal sealed class IdleShipState : ShipState
    {
        internal override void Handle(Context context)
        {
            context.ShipState = new MovingShipState();
        }

        internal override void Loop()
        {
            System.Console.WriteLine("current state : idle");
        }
    }
}