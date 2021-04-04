using UnityEngine;


namespace Assets.Homework5.GunDecorator
{
    internal interface IAmmunition
    {
        Rigidbody2D BulletInstance { get; }
        float TimeToDestroy { get; }
    }
}