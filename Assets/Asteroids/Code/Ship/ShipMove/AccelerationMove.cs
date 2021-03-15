using UnityEngine;


namespace Asteroids
{
    internal sealed class AccelerationMove : MoveTransform
    {
        #region Fields

        private readonly float _acceleration;

        #endregion


        #region ClassLifeCycles

        internal AccelerationMove(Transform transform, float speed, float acceleration)
            : base(transform, speed)
        {
            _acceleration = acceleration;
        }

        #endregion


        #region Methods

        internal void AddAcceleration()
        {
            Speed += _acceleration;
        }

        internal void RemoveAcceleratiom()
        {
            Speed -= _acceleration;
        }

        #endregion
    }
}