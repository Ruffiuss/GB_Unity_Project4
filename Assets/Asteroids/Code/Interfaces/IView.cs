using UnityEngine;
using System;


namespace Asteroids
{
    internal interface IView
    {
        event Action<GameObject> ProviderDestroyed;
        void OnCollisionEnter2D(Collision2D collision);
    }
}