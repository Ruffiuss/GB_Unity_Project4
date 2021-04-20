using UnityEngine;


namespace Asteroids
{
    internal abstract class SpawnLogger
    {
        internal abstract void SpawnLogInfo(IDealingLogInfo value, string name, Vector3 position);
    }
}