using UnityEngine;
using System;


namespace Asteroids
{
    internal sealed class Ship : IController, IPlayerContorllable, ITrackable
    {
        #region Fields

        private IMove _moveImpementation;
        private IRotation _rotationImplementation;
        private IShipWeapon _weapon;

        private ShipModel _model;

        #endregion

        #region Properties

        public float Speed => _model.Speed;
        public Transform TargetPosition => _model.ProviderPosition;

        public event Action<GameObject, bool> ReloadRequired;

        #endregion


        #region ClassLifeCycles

        internal Ship(IMove moveImplementation, IRotation rotationImplemetation, IShipWeapon weapon, ShipModel model)
        {
            _model = model;
            _moveImpementation = moveImplementation;
            _rotationImplementation = rotationImplemetation;
            _weapon = weapon;
            _weapon.EquipWeapon(_model.BarrelPosition);
            _weapon.Activate();
        }

        #endregion


        #region Methods

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImpementation.Move(horizontal, vertical, deltaTime);
        }
        
        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction - Camera.main.WorldToScreenPoint(_model.ProviderPosition.position));
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
            if(isPressed) _weapon.Shoot();
        }

        public void ReloadWeapon(bool isPressed)
        {
            if (isPressed) _weapon.Reload();
        }

        public IPlayerContorllable ReloadShip(IMove moveImplementation, IRotation rotationImplemetation, ShipModel model)
        {
            _model = model;
            _moveImpementation = moveImplementation;
            _rotationImplementation = rotationImplemetation;
            return this;
        }

        public void WatchToProviderDestroyed(GameObject provider)
        {
            ReloadRequired.Invoke(provider, false);
        }

        #endregion
    }
}