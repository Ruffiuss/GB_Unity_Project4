using UnityEngine;


namespace Asteroids
{
    internal sealed class ConsoleDisplayLogInfo : IDealLogInfo
    {
        public void SpawnLogInfo(InfoSpawnLog info)
        {
            Debug.Log($"Spawned: {info.Name} at {info.Position}");
        }
    }
}