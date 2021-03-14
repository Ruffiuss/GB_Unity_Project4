namespace Asteroids
{
    internal interface IShipWeapon
    {
        float MaxAmmo { get; }
        float CurrentAmmo { get; set; }
        void Shoot();
        void Reload();
    }
}