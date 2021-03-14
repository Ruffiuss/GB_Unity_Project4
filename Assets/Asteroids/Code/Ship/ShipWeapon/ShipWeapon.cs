namespace Asteroids
{
    internal sealed class ShipWeapon : IShipWeapon
    {
        #region Fields



        #endregion


        #region Properties

        public float MaxAmmo => throw new System.NotImplementedException();
        public float CurrentAmmo { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        #endregion


        #region Methods

        public void Reload()
        {
            throw new System.NotImplementedException();
        }

        public void Shoot()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}