using UnityEngine;
using System;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Ship", menuName = "Data/Ship")]
    public class ShipData : ScriptableObject, ICloneable
    {
        public GameObject Provider; 
        public float Speed;
        public float Acceleration;
        public float HP;
        public float Force;

        public object Clone()
        {
            return new ShipData
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