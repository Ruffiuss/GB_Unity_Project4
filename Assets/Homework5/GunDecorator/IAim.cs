using UnityEngine;


namespace Assets.Homework5.GunDecorator
{
    internal interface IAim
    {
        Transform AimPosition { get; }
        GameObject AimInstance { get; }
    }
}