using UnityEngine;


namespace Asteroids
{
    internal sealed class Ship : IExecutable, IPlayable, ITrackable
    {
        #region Fields

        private AccelerationMove _accelerationMove;
        private RotationShip _rotationShip;
        private ShipModel _model;

        public Transform TargetPosition => _model.ProvidePosition;

        #endregion


        #region ClassLifeCycles

        internal Ship(AccelerationMove accelerationMove, RotationShip rotationShip, ShipModel model)
        {
            _accelerationMove = accelerationMove;
            _rotationShip = rotationShip;
            _model = model;
        }

        #endregion


        #region Methods

        public void Execute(float deltaTime)
        {
        }

        public void Rotation(Vector3 direction)
        {
            //direction -= _camera.WorldToScreenPoint(_model.ProvidePosition.position);
            _model.Provider.transform.Rotate(direction);
        }

        public void Move(float horizontal, float vertical)
        {
            _model.Provider.transform.position += new Vector3(horizontal, vertical);
        }

        public void AddAcceleration()
        {
            Debug.Log("accelereate keydown");
        }

        public void RemoveAcceleration()
        {
            Debug.Log("accelereate keyup");
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