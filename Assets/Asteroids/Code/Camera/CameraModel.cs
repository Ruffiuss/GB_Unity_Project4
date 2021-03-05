namespace Asteroids
{
    internal sealed class CameraModel
    {
        #region Fields

        private CameraData _data;

        #endregion


        #region Properties

        internal 


        #region ClassLifeCycles

        internal CameraModel(Cammera camera, CameraData data, ITrackable target)
        {
            _data = (CameraData)data.Clone();
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