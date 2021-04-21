using UnityEngine;


namespace Asteroids
{
    internal sealed class Context
    {
        #region Fields

        private ShipState _shipState;

        #endregion


        #region ClassLifeCycles

        internal Context(ShipState shipState)
        {
            _shipState = shipState;
        }

        #endregion


        #region Methods



        #endregion
    }
}