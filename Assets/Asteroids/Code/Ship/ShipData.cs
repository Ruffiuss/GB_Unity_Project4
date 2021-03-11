using UnityEngine;
using System;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Ship", menuName = "Data/Ship")]
    public class ShipData : ScriptableObject
    {
        public GameObject Provider; 
        public float Speed;
        public float Acceleration;
        public float HP;
        public float Force;
    }
}