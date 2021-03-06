using UnityEngine;


namespace Asteroids
{
    internal sealed class CameraModel
    {
        #region Fields

        private CameraData _data;

        #endregion


        #region Properties

        internal Camera MainCamera => _data.MainCamera;
        internal Transform Target => _data.Target.TargetPosition;

        #endregion


        #region ClassLifeCycles

        internal CameraModel(Camera camera, ITrackable target)
        {
            _data = new CameraData();
            _data.MainCamera = camera;
            _data.Target = target;
        }

        #endregion


        #region Methods

        internal void ChangeTarget(ITrackable target)
        {
            _data.Target = target;
        }

        #endregion
    }
}