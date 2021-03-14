using UnityEngine;
using System;


namespace Asteroids
{
    internal sealed class Ship : IController, IPlayable, ITrackable
    {
        #region Fields

        private IMove _moveImpementation;
        private IRotation _rotationImplementation;

        private ShipModel _model;

        #endregion

        #region Properties

        public float Speed => _model.Speed;
        public Transform TargetPosition => _model.ProvidePosition;
        public event Action<GameObject, bool> ReloadRequired;

        #endregion


        #region ClassLifeCycles

        internal Ship(IMove moveImplementation, IRotation rotationImplemetation, ShipModel model)
        {
            _model = model;
            _moveImpementation = moveImplementation;
            _rotationImplementation = rotationImplemetation;
        }

        #endregion


        #region Methods

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImpementation.Move(horizontal, vertical, deltaTime);
        }
        
        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction - Camera.main.WorldToScreenPoint(_model.ProvidePosition.position));
        }

        public void AddAcceleration()
        {
            if ((IMove)_moveImpementation is AccelerationMove accelerationMove) accelerationMove.AddAcceleration();
        }

        public void RemoveAcceleration()
        {
            if ((IMove)_moveImpementation is AccelerationMove accelerationMove) accelerationMove.RemoveAcceleratiom();
        }

        public void MainFire(bool isPressed)
        {
            if(isPressed) Debug.Log("fire1 keydown");
            //var temAmmunition = Instantiate(_bullet ,_barrel.position , _barrel.rotation);
            //temAmmunition.AddForce(_barrel.up * _model.Force);
        }

        public IPlayable ReloadShip(IMove moveImplementation, IRotation rotationImplemetation, ShipModel model)
        {
            _model = model;
            _moveImpementation = moveImplementation;
            _rotationImplementation = rotationImplemetation;
            return this;
        }

        public void WatchToProviderDestroyed(GameObject provider, bool isDestroyed)
        {
            if (isDestroyed) ReloadRequired.Invoke(provider, false);
        }

        #endregion
    }
}