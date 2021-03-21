namespace Asteroids
{
    internal interface IWeaponFactory : IFactory
    {
        IShipWeapon GetShipWeapon { get; }
        IShipWeapon CreateWeaponFromData(ShipWeaponData data);
    }
}