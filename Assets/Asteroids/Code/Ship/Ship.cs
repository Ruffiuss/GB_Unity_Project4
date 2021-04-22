using UnityEngine;
using System;


namespace Asteroids
{
    internal sealed class Ship : IExecutable, IPlayerContorllable, ITrackable, IScoreSource // temporary solution
    {
        #region Fields

        private IMove _moveImpementation;
        private IRotation _rotationImplementation;
        private IShipWeapon _weapon;

        private ShipModel _model;
        private ShipModifier _modifier; // temporary solution
        private Context _currentContext;

        #endregion


        #region Properties

        public float Health => _model.CurrentHealth;
        public float Speed => _model.Speed;
        public float SpeedMultiplier
        { 
            set
            {
                _moveImpementation.SpeedMultiplier = value; 
            } 
        }

        public Transform TargetPosition => _model.ProviderPosition;

        public event Action<GameObject, bool> ReloadRequired;
        public event Action<int> OnScoreChange;

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
            _modifier = new ShipModifier(this); // temporary solution
            _currentContext = new Context(new IdleShipState()); // temporary solution
        }

        #endregion


        #region Methods

        public void Execute(float deltaTime)
        {
            _currentContext.DoLoop();
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImpementation.Move(horizontal, vertical, deltaTime);
            _currentContext.ShipState = new MovingShipState(); // temporary solution
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
            OnScoreChange.Invoke(20); // temporary solution
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

        public void WatchForProviderDestroyed(GameObject provider)
        {
            ReloadRequired.Invoke(provider, false);
        }

        public void ChangeHealth(float value)
        {
            _model.UpdateHealth(value);
        }

        public void AddModifier(int index)
        {
            switch (index)
            {
                case 0:
                    _modifier.Add(new AddSpeedModifier(this, 1.5f));
                    _modifier.Add(new AddHealthModifier(this, 20.0f));
                    break;
                case 1:
                    _modifier.Add(new AddSpeedModifier(this, 2.5f));
                    _modifier.Add(new AddHealthModifier(this, 30.0f));
                    break;
                default:
                    break;
            }
            _modifier.Handle();
        }

        // temporary 
        public void CollisionHandler(Collision2D collision)
        {            
            Debug.Log($"Collision with:{collision.gameObject.name}");
            ChangeHealth(-1.0f);
        }
        // solution

        #endregion
    }
}