using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Camera", folderName = "Data/Camera")]
    internal sealed class CameraData : ScriptableObject
    {
        public Camera MainCamera;
        public ITrackable Target;
    }
}