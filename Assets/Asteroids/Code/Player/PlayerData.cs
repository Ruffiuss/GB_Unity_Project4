using UnityEngine;
using System;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/Player")]
    internal sealed class PlayerData : ScriptableObject, ICloneable
    {
        public IPlayable Ship;
        public object Clone()
        {
            return new PlayerData();
        }
    }
}