using System.Collections.Generic;


namespace Asteroids
{
    internal sealed class Controllers : IExecutable, ICleanupable
    {
        #region Fields

        private List<IExecutable> _executables;
        private List<ILateExecutable> _lateExecutables;
        private List<ICleanupable> _cleanupables;

        #endregion


        #region ClassLifeCycles

        internal Controllers()
        {
            _executables = new List<IExecutable>();
            _cleanupables = new List<ICleanupable>();
            _lateExecutables = new List<ILateExecutable>();
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
        public void LateExecute(float deltaTime)
        {
            foreach (var lateExecutable in _lateExecutables)
            {
                lateExecutable.LateExecute(deltaTime);
            }
        }
        public void Cleanup()
        {
            foreach (var cleanupable in _cleanupables)
            {
                cleanupable.Cleanup();
            }
        }

        public void AddController(IController controller)
        {
            if(controller is IExecutable executable) _executables.Add(executable);
            if(controller is ILateExecutable lateExecutable) _lateExecutables.Add(lateExecutable);
            if(controller is ICleanupable cleanupable) _cleanupables.Add(cleanupable);
        }

        #endregion
    }
}