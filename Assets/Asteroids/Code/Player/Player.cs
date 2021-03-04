using UnityEngine;


namespace Asteroids
{
	internal sealed class Player : MonoBehaviour, IControllable
	{
		#region Fields

		[SerializeField] private Rigidbody2D _bullet;
		[SerializeField] private Transform _barrel;
		[SerializeField] private float _speed;
		[SerializeField] private float _acceleration;
		[SerializeField] private float _hp;
		[SerializeField] private float _force;

		private Camera _camera;
		private Ship _ship;

		private readonly PlayerModel _model;

		#endregion


		#region Methods

		internal Player(PlayerModel model)
		{
			_model = model;
		}

		public void Execute(float deltaTime)
		{
			var direction = Input.mousePosition -
			_camera.WorldToScreenPoint(transform.position);
			_ship.Rotation (direction);
			_ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis( "Vertical" ),
			Time.deltaTime);

			if (Input.GetKeyDown(KeyCode.LeftShift))
			{
				_ship.AddAcceleration();
			}

			if (Input.GetKeyUp(KeyCode.LeftShift))
			{
				_ship.RemoveAcceleration();
			}

			if (Input.GetButtonDown("Fire1"))
			{
				var temAmmunition = Instantiate(_bullet ,_barrel.position ,
				_barrel.rotation);
				temAmmunition.AddForce(_barrel.up * _force);
			}
		}

		#endregion


		#region UnityMethods

		private void Start ()
		{
			_camera = Camera.main;
			var moveTransform = new AccelerationMove(transform , _speed,
			_acceleration);
			var rotation = new RotationShip(transform);
			_ship = new Ship(moveTransform, rotation);
		}
		
		private void OnCollisionEnter2D(Collision2D other)
		{
			if (_hp <= 0)
			{
				Destroy(gameObject);
			}
			else
			{
				_hp --;
			}
		}

		#endregion
	}
}