using UnityEngine;


namespace Asteroids
{
    internal sealed class ShipWeaponModel
    {
        #region Fields

        private readonly ShipWeaponData _data;

        #endregion


        #region Properties

        internal GameObject Provider => _data.Provider;
        internal float Force => _data.Force;
        internal float MaxAmmo => _data.MaxAmmo;
        internal float CurrentAmmo { get; private set; }
        internal bool IsReady { get; private set; }
        internal Transform BulletStart { get; }

        #endregion


        #region ClassLifeCycles

        internal ShipWeaponModel(ShipWeaponData data)
        {
            _data = data;
            BulletStart = _data.Provider.transform;
        }

        #endregion


        #region Methods

        internal void AddAmmo(float ammo)
        {
            CurrentAmmo += ammo;
        }

        internal void ReloadAmmo()
        {
            IsReady = false;
            CurrentAmmo = MaxAmmo;
        }

        internal void RemoveAmmo(float ammo)
        {
            CurrentAmmo -= ammo;
        }

        internal void SetWeaponActive()
        {
            IsReady = true;
        }

        #endregion
    }
}