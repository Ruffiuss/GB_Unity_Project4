using UnityEngine;


namespace Asteroids
{
    internal sealed class ShipWeapon : IShipWeapon
    {
        #region Fields

        private readonly ShipWeaponModel _model;
        private IPool<GameObject> _bulletsPool;

        #endregion


        #region Properties

        public float CurrentAmmo
        {
            get => _model.CurrentAmmo;
            private set
            {
                if (value > 0)
                {
                    if (_model.CurrentAmmo < _model.MaxAmmo)
                    {
                        var ammoNeeded = _model.MaxAmmo - _model.CurrentAmmo;

                        if (value <= ammoNeeded)
                        {
                            _model.AddAmmo(value);
                        }
                        else
                        {
                            _model.AddAmmo(ammoNeeded);
                        }
                    }
                }
                else if(value < 0)
                {
                    _model.RemoveAmmo(value);
                }
            } 
        }

        #endregion


        #region ClassLifeCycles

        internal ShipWeapon(ShipWeaponModel model, IPool<GameObject> bulletsPool)
        {
            _bulletsPool = bulletsPool;
            _model = model;
            _model.ReloadAmmo();
        }

        #endregion


        #region Methods

        public void Reload()
        {
            _model.ReloadAmmo();
        }

        public void Shoot()
        {
            if (_model.IsReady)
            {
                CurrentAmmo -= 1;
                var bullet = _bulletsPool.Pop();
                bullet.transform.position = _model.BulletStart.position;
                bullet.transform.rotation = _model.BulletStart.rotation;
            }
        }

        #endregion
    }
}