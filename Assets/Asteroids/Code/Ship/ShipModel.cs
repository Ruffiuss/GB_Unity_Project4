using UnityEngine;


namespace Asteroids
{
    internal sealed class ShipModel
    {
        #region Fields

        private ShipData _data;

        #endregion


        #region Properties

        internal float Speed => _data.Speed;
        internal float BaseHealth => _data.HP;
        internal float CurrentHealth { get; private set; }
        internal float Acceleration => _data.Acceleration;
        internal Transform ProviderPosition => _data.Provider.transform;
        internal Transform BarrelPosition => _data.Provider.transform.GetChild(0).GetComponentInChildren<Transform>();

        #endregion


        #region ClassLifeCycles

        internal ShipModel(ShipData data)
        {
            _data = data;
            CurrentHealth = BaseHealth;
        }

        #endregion


        #region Methods

        internal void UpdateHealth(float value)
        {
            CurrentHealth += value;
        }

        #endregion
    }
}