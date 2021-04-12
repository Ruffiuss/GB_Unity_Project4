using UnityEngine;


namespace Asteroids
{
    internal sealed class ShipWeaponFactory : IWeaponFactory
    {
        #region Fields

        private ShipWeaponData _data;
        private IPool<GameObject> _bulletsPool;

        #endregion


        #region Properties

        public IShipWeapon GetShipWeapon { get; private set; }

        #endregion


        #region ClassLifeCycles

        internal ShipWeaponFactory(ShipWeaponData data, IPool<GameObject> bulletsPool)
        {
            _data = data;
            _bulletsPool = bulletsPool;
            GetShipWeapon = CreateWeaponFromData(_data);
        }

        #endregion


        #region Methods

        public IShipWeapon CreateWeaponFromData(ShipWeaponData data)
        {
            var spawnedWeapon = Object.Instantiate(data.Provider);
            spawnedWeapon.SetActive(false);

            var shipWeaponModel = new ShipWeaponModel(
                new ShipWeaponData()
                {
                    Provider = spawnedWeapon,
                    Bullet = data.Bullet,
                    MaxAmmo = data.MaxAmmo,
                    RateOfFire = data.RateOfFire,
                    ReloadSpeed = data.ReloadSpeed,
                    Force = data.Force
                });

            GetShipWeapon = new ShipWeaponJammer(new ShipWeapon(shipWeaponModel, _bulletsPool));

            return GetShipWeapon;
        }

        #endregion
    }
}