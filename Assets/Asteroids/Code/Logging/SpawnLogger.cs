using UnityEngine;


namespace Asteroids
{
    internal abstract class SpawnLogger
    {
        internal abstract void SpawnLogInfo(IDealLogInfo value, string name, Vector3 position);
    }
}