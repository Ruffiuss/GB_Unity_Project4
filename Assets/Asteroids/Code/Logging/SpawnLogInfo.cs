using UnityEngine;

namespace Asteroids
{
    public readonly struct InfoSpawnLog
    {
        private readonly Vector3 _piosition;
        private readonly string _name;

        public Vector3 Position => _piosition;
        public string Name => _name;

        public InfoSpawnLog(Vector3 position, string name)
        {
            _piosition = position;
            _name = name;
        }
    }
}