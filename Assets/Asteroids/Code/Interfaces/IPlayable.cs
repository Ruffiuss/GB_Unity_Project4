using UnityEngine;
using System;


namespace Asteroids
{
    internal interface IPlayable: IMove, IRotation
    {
        event Action<GameObject, bool> ReloadRequired;
        void MainFire(bool isPressed);
        void AddAcceleration();
        void RemoveAcceleration();
        IPlayable ReloadShip(IMove moveImplementation, IRotation rotationImplemetation, ShipModel model);
        void WatchToProviderDestroyed(GameObject provider, bool isDestroyed);
    }
}