using UnityEngine;


namespace Asteroids
{
    public interface ITrackable
    {
        Transform TargetPosition { get; }
    }
}