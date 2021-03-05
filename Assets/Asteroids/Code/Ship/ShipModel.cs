using UnityEngine;


namespace Asteroids
{
    internal sealed class ShipModel
    {
        #region Fields

        private ShipData _data;

        #endregion


        #region ClassLifeCycles

        internal ShipModel(ShipData data)
        {
            _data = data;
        }

        #endregion
    }
}