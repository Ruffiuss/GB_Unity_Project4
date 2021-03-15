using UnityEngine;
using System;


namespace Asteroids
{
    internal interface IDamagable : IView
    {
        event Action<Collision2D> Collision;
    }
}