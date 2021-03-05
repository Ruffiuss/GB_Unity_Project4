using UnityEngine;


namespace Asteroids
{
    internal sealed class Player : MonoBehaviour, IExecutable, ITrackable
    {
        #region Fields

        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;

        private Camera _camera;
        private Ship _ship;

        private readonly PlayerModel _model;

        #endregion


        #region Properties

        public Transform TargetPosition => _model.ProvidePosition;

        #endregion
        

        #region Methods

        internal Player(PlayerModel model)
        {
            _model = model;
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(_model.ProvidePosition, _model.Speed, _model.Acceleration);
            var rotation = new RotationShip(_model.ProvidePosition);
            _ship = new Ship(moveTransform, rotation);
        }

        public void Execute(float deltaTime)
        {
            var direction = Input.mousePosition; - _camera.WorldToScreenPoint(_model.ProvidePosition.position);
            _ship.Rotation(direction);
            _ship.Move(
                Input.GetAxis(InputManager.HORIZONTAL_AXIS),
                Input.GetAxis(InputManager.VERTICAL_AXIS),
                deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown(InputManager.PLAYER_FIRE1))
            {
                //var temAmmunition = Instantiate(_bullet ,_barrel.position , _barrel.rotation);
                //temAmmunition.AddForce(_barrel.up * _model.Force);
            }
        }

        #endregion


        #region UnityMethods
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_model.Health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _model.ChangeHealth(-1);
            }
        }

        #endregion
    }
}