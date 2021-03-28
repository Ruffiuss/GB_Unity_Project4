using UnityEngine;


namespace Assets.Homework5.GunDecorator
{
    internal abstract class ModificationWeapon : IFire
    {
        private Weapon _weapon;

        protected abstract Weapon AddModification(Weapon weapon);

        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
        }

        public void Fire()
        {
            _weapon.Fire();
        }

        public abstract GameObject GetProvider();
    }
}