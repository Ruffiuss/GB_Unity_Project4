namespace Asteroids
{
    internal interface IShipWeapon
    {
        float CurrentAmmo { get; }
        void Shoot();
        void Reload();
    }
}