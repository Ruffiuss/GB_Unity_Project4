namespace Asteroids
{
    internal interface IShipFactory : IFactory
    {
        Ship CreateShipFromData(ShipData data);
    }
}