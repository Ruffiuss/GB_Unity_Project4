using UnityEngine;


namespace Assets.Homework5.GunDecorator
{
    internal sealed class ModificationAim : ModificationWeapon
    {
        #region Fields

        private readonly IAim _aim;
        private readonly Vector3 _aimPosition;
        private GameObject _currentProvider;

        #endregion


        #region ClassLifeCycles

        public ModificationAim(IAim aim, Vector3 aimPosition)
        {
            _aim = aim;
            _aimPosition = aimPosition;
        }

        #endregion


        #region Methods

        protected override Weapon AddModification(Weapon weapon)
        {
            _currentProvider = Object.Instantiate(_aim.AimInstance, _aimPosition, Quaternion.identity);
            return weapon;
        }

        public override GameObject GetProvider()
        {
            return _currentProvider;
        }

        #endregion
    }
}