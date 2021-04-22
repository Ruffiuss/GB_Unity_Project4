using UnityEngine;


namespace Asteroids
{
    internal sealed class Context
    {
        #region Fields

        private ShipState _shipState;

        #endregion


        #region Properties

        internal ShipState ShipState
        {
            set
            {
                _shipState = value;
                Debug.Log($"State: {_shipState.GetType().Name}");
            }
        }

        #endregion


        #region ClassLifeCycles

        internal Context(ShipState shipState)
        {
            _shipState = shipState;
        }

        #endregion


        #region Methods

        internal void Request()
        {
            _shipState.Handle(this);
        }

        internal void DoLoop()
        {
            _shipState.Loop();
        }

        #endregion
    }
}