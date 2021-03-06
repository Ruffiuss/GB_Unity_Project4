using UnityEngine;


namespace Asteroids
{
    internal sealed class Player : IExecutable
    {
        #region Fields

        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;

        //private Camera _camera;
        private IPlayable _ship;

        private readonly PlayerModel _model;

        #endregion
        

        #region Methods

        internal Player(PlayerModel model, IInputProxy input)
        {
            _model = model;
            //_camera = Camera.main;
            //var moveTransform = new AccelerationMove(_model.ProvidePosition, _model.Speed, _model.Acceleration);
            //var rotation = new RotationShip(_model.ProvidePosition);
            // new Ship(moveTransform, rotation);
            _ship = _model.Ship;
            input.AxisOnChange += _ship.Move;
            input.AccelerationOnChange += AccelerationChange;
            input.MouseAxisOnChange += _ship.Rotation;
            input.MainFireOnPressed += _ship.MainFire;
        }

        public void Execute(float deltaTime)
        {
        }

        private void AccelerationChange(bool isPressed)
        {
            if (isPressed) _ship.AddAcceleration();
            else _ship.RemoveAcceleration();
        }

        #endregion


        #region UnityMethods
        
        //private void OnCollisionEnter2D(Collision2D other)
        //{
        //    if (_model.Health <= 0)
        //    {
        //        Destroy(gameObject);
        //    }
        //    else
        //    {
        //        _model.ChangeHealth(-1);
        //    }
        //}

        #endregion
    }
}