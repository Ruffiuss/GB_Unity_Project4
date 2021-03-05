using UnityEngine;
using System;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Ship", folderName = "Data/Ship")]
    public class ShipData : ScriptableObject, ICloneable
    {
        public object Clone()
        {
            return new ShipData
            {

            };
        }
    }
}