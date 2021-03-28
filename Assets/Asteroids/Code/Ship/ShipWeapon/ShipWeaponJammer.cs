using UnityEngine;

namespace Asteroids
{
    internal sealed class ShipWeaponJammer : IShipWeapon
    {
        #region Fields

        private readonly IShipWeapon _weapon;
        private bool _isJammed;

        #endregion


        #region Properties

        public float CurrentAmmo => _weapon.CurrentAmmo;

        #endregion


        #region ClassLifeCycles

        public ShipWeaponJammer(IShipWeapon shipWeapon)
        {
            _weapon = shipWeapon;
            _isJammed = false;
        }

        #endregion


        #region Methods

        public void Activate()
        {
            _weapon.Activate();
        }

        public void EquipWeapon(Transform targetPosition)
        {
            _weapon.EquipWeapon(targetPosition);
        }

        public void Reload()
        {
            _weapon.Reload();
            _isJammed = false;
        }

        public void Shoot()
        {
            int jamState = Random.Range(0, 100);
            Debug.Log(jamState);
            if (jamState >= 99)
            {
                _isJammed = true;
            }

            if (!_isJammed)
            {
                _weapon.Shoot();
            }
            else
            {
                Debug.Log("Weapon is jammed!");
            }
        }

        #endregion

    }
}