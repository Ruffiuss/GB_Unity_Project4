using UnityEngine;
using System;


namespace Asteroids
{
	[CreateAssetMenu(fileName = "Player", menuName = "Data/Player")]
	public sealed class PlayerData : ScriptableObject, ICloneable
	{
		public GameObject Provider;
		public float Speed;
		public float Acceleration;
		public float HP;
		public float Force;

		public object Clone()
		{
			return new PlayerData
			{
				Provider = this.Provider,
				Speed = this.Speed,
				Acceleration = this.Acceleration,
				HP = this.HP,
				Force = this.Force
			};
		}
	}
}