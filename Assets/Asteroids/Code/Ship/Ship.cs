using UnityEngine;


namespace Asteroids
{
    internal sealed class Ship : IExecutable
    {
        #region ClassLifeCycles

        internal Ship(AccelerationMove accelerationMove, RotationShip rotationShip)
        {

        }

        #endregion


        #region Methods

        public void Execute(float deltaTime)
        {
            Debug.Log("imma shipp");
        }

        public void Rotation(Vector3 direction)
        {

        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {

        }

        public void AddAcceleration()
        {

        }

        public void RemoveAcceleration()
        {

        }

        #endregion
    }
}