using System.Collections.Generic;


namespace Asteroids
{
    internal sealed class Controllers : IExecutable, ICleanupable
    {
        #region Fields

        private List<IExecutable> _executables;
        private List<ICleanupable> _cleanupables;

        #endregion


        #region ClassLifeCycles

        internal Controllers()
        {
            _executables = new List<IExecutable>();
            _cleanupables = new List<ICleanupable>();
        }

        #endregion


        #region Methods

        public void Execute(float deltaTime)
        {
            foreach(var executable in _executables)
            {
                executable.Execute(deltaTime);
            }
        }
        public void Cleanup()
        {
            foreach (var cleanupable in _cleanupables)
            {
                cleanupable.Cleanup();
            }
        }

        public void AddController(IControllable controller)
        {
            if(controller is IExecutable executable) _executables.Add(executable);
            if(controller is ICleanupable cleanupable) _cleanupables.Add(cleanupable);
        }

        #endregion
    }
}