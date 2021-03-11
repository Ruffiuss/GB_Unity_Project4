using UnityEngine;


namespace Asteroids
{
    internal sealed class ShipModel
    {
        #region Fields

        private readonly IMove _moveImpementation;
        private readonly IRotation _rotationImplementation;
        private ShipData _data;

        #endregion


        #region Properties

        internal float Speed => _moveImpementation.Speed;
        internal float Acceleration => _data.Acceleration;
        internal Transform ProvidePosition => _data.Provider.transform;

        #endregion


        #region ClassLifeCycles

        internal ShipModel(IMove moveImplementation, IRotation rotationImplemetation, ShipData data)
        {
            _data = data;
            _moveImpementation = moveImplementation;
            _rotationImplementation = rotationImplemetation;
        }

        #endregion
    }
}