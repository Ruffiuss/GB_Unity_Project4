using UnityEngine;


namespace Asteroids
{
    internal interface IShipWeapon
    {
        float CurrentAmmo { get; }
        void EquipWeapon(Transform targetPosition);
        void Activate();
        void Shoot();
        void Reload();
    }
}