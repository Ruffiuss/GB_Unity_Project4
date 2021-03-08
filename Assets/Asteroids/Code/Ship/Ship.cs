using UnityEngine;


namespace Asteroids
{
    internal sealed class Ship : IController, IPlayable, ITrackable
    {
        #region Fields

        private readonly IMove _moveImpementation;
        private readonly IRotation _rotationImplementation;

        private ShipModel _model;

        #endregion

        #region Properties

        public float Speed => _moveImpementation.Speed;
        public Transform TargetPosition => _model.ProvidePosition;

        #endregion


        #region ClassLifeCycles

        internal Ship(IMove moveImplementation, IRotation rotationImplemetation, ShipModel model)
        {
            _moveImpementation = moveImplementation;
            _rotationImplementation = rotationImplemetation;
            _model = model;
        }

        #endregion


        #region Methods

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImpementation.Move(horizontal, vertical, deltaTime);
        }
        
        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if (_moveImpementation is AccelerationMove accelerationMove) accelerationMove.AddAcceleration();
        }

        public void RemoveAcceleration()
        {
            if (_moveImpementation is AccelerationMove accelerationMove) accelerationMove.RemoveAcceleratiom();
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