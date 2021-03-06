using UnityEngine;


namespace Asteroids
{
    internal sealed class CameraInitializer
    {
        #region Properties

        internal IControllable CameraController { get; }

        #endregion


        #region ClassLifeCycles

        internal CameraInitializer(CameraData data, ITrackable target)
        {
            var mainCam = Camera.main;
            CameraController = new CameraController(new CameraModel(mainCam, target));
        }

        #endregion
    }
}