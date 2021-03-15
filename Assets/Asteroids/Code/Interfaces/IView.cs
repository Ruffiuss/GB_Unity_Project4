using UnityEngine;
using System;


namespace Asteroids
{
    internal interface IView
    {
        event Action<GameObject, bool> ProviderDestroyed;
    }
}