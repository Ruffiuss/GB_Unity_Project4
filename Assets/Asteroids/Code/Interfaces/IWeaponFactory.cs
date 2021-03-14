namespace Asteroids
{
    internal interface IWeaponFactory : IFactory
    {
        IShipWeapon CreateWeaponFromData(ShipWeaponData data);
    }
}