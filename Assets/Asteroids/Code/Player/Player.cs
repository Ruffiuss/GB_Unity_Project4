	internal sealed class Player : MonoBehaviour
	{
		[SerializeField] private float _speed ;
		[SerializeField] private float _acceleration ;
		[SerializeField] private float _hp ;
		[SerializeField] private Rigidbody2D _bullet ;
		[SerializeField] private Transform _barrel ;
		[SerializeField] private float _force ;

		private Camera _camera ;
		private Ship _ship ;

		private void Start ()
		{
			_camera = Camera.main;
			var moveTransform = new AccelerationMove(transform , _speed,
			_acceleration);
			var rotation = new RotationShip(transform);
			_ship = new Ship(moveTransform, rotation);
		}

		private void Update ()
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
	}
}
