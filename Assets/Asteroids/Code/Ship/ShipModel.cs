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
        internal float Acceleration => _data.Acceleration;
        internal Transform ProvidePosition => _data.Provider.transform;

        #endregion


        #region ClassLifeCycles

        internal ShipModel(ShipData data)
        {
            _data = data;
        }

        #endregion
    }
}