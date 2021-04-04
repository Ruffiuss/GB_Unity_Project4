using UnityEngine;
using System;


namespace Asteroids
{
    internal interface IPlayerContorllable: IMove, IRotation
    {
        float Health { get; }
        event Action<GameObject, bool> ReloadRequired;
        void MainFire(bool isPressed);
        void ReloadWeapon(bool isPressed);
        void AddAcceleration();
        void RemoveAcceleration();
        IPlayerContorllable ReloadShip(IMove moveImplementation, IRotation rotationImplemetation, ShipModel model);
        void WatchForProviderDestroyed(GameObject provider);
        void AddModifier(int index);
    }
}