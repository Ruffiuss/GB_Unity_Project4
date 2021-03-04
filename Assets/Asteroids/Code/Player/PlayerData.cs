using UnityEngine;
using System;


namespace Asteroids
{
	[CreateAssetMenu(fileName - "Player", menuName = "Data")]
	public sealed class PlayerData : ScriptableObject, ICloneable
	{
		[SerializeField] private float _speed;
		[SerializeField] private float _acceleration;
		[SerializeField] private float _hp;
		[SerializeField] private float _force;

		public void Clone()
		{
			return new PlayerData
			{
				_speed = this._speed;
				_acceleration = this._acceleration;
				_hp = this._hp;
				_force = this._force;
			}
		}
	}
}