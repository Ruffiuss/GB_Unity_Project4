namespace Asteroids
{
    internal sealed class CameraController : IExecutable
    {
        #region Fields

        private CameraModel _model;

        #endregion


        #region ClassLifeCycles

        internal CameraController(CameraModel model)
        {
            _model = model;
        }

        #endregion


        #region Methods

        public void Execute(float deltaTime)
        {
            _model.Camera 
        }
    }
}