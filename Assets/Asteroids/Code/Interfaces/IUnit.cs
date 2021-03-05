using UnityEngine;


namespace Asteroids
{
    public interface IUnit
    {
        Transform ProviderTranform { get; }
    }
}