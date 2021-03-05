using System.Collections.Generic;


namespace Asteroids
{
    internal sealed class Controllers : IExecutable
    {
        #region Fields

        private List<IExecutable> _executables;

        #endregion


        #region ClassLifeCycles

        internal Controllers()
        {
            _executables = new List<IExecutable>();
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

        public void AddController(IControllable controller)
        {
            if(controller is IExecutable executable) _executables.Add(executable);
        }

        #endregion
    }
}