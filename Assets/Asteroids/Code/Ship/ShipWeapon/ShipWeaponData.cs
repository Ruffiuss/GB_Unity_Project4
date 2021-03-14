using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "ShipWeapon", menuName = "Data/ShipWeapon")]
    public sealed class ShipWeaponData : ScriptableObject
    {
        #region Fields

        public GameObject Provider;
        public float MaxAmmo;
        public float RateOfFire;
        public float ReloadSpeed;

        #endregion
    }
}