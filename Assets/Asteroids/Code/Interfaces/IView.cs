using UnityEngine.EventSystems;
using UnityEngine;
using System;


namespace Asteroids
{
    internal interface IView : IEventSystemHandler
    {
        event Action<GameObject> ProviderDestroyed;
        void ProviderDestroyedMessage();
    }
}