using UnityEngine;
using System;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Camera", menuName = "Data/Camera")]
    public sealed class CameraData : ScriptableObject, ICloneable
    {
        public Camera MainCamera;
        public ITrackable Target;

        public object Clone()
        {
            return new CameraData
            {
                MainCamera = this.MainCamera,
                Target = this.Target
            };
        }
    }
}