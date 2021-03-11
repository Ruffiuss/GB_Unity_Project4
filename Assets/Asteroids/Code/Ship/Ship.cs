using UnityEngine;


namespace Asteroids
{
    internal sealed class Ship : IController, IPlayable, ITrackable
    {
        #region Fields

        private ShipModel _model;

        #endregion

        #region Properties

        public float Speed => _model.Ship.Speed;
        public Transform TargetPosition => _model.ProvidePosition;

        #endregion


        #region ClassLifeCycles

        internal Ship(ShipModel model)
        {
            _model = model;
        }

        #endregion


        #region Methods

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _model.Ship.Move(horizontal, vertical, deltaTime);
        }
        
        public void Rotation(Vector3 direction)
        {
            _model.Ship.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if ((IMove)_model.Ship is AccelerationMove accelerationMove) accelerationMove.AddAcceleration();
        }

        public void RemoveAcceleration()
        {
            if ((IMove)_model.Ship is AccelerationMove accelerationMove) accelerationMove.RemoveAcceleratiom();
        }

        public void MainFire(bool isPressed)
        {
            if(isPressed) Debug.Log("fire1 keydown");
            //var temAmmunition = Instantiate(_bullet ,_barrel.position , _barrel.rotation);
            //temAmmunition.AddForce(_barrel.up * _model.Force);
        }

        #endregion
    }
}