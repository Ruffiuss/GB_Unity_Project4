using UnityEngine;


namespace Asteroids
{
    internal sealed class ShipModel
    {
        #region Fields

        private ShipData _data;

        #endregion


        #region Properties

        internal GameObject Provider => _data.Provider;
        internal float Speed => _data.Speed;
        internal float Acceleration => _data.Acceleration;
        internal float Force => _data.Force;
        internal float Health => _data.HP;
        internal Transform ProvidePosition => _data.Provider.transform;

        #endregion


        #region ClassLifeCycles

        internal ShipModel(GameObject provider, ShipData data)
        {
            _data = (ShipData)data.Clone();
            _data.Provider = provider;
        }

        #endregion
    }
}