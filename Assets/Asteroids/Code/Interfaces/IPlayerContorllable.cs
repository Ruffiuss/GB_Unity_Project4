using System.Collections.Generic;
using System.Collections;
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
        IAbility this[int index] { get; }
        string this[Target index] { get; }
        int MaxDamage { get; }
        IEnumerable<IAbility> GetAbility();
        IEnumerator GetEnumerator();
        IEnumerable<IAbility> GetAbility(DamageType index);
    }
}