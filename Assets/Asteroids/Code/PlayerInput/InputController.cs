namespace Asteroids
{
    internal sealed class InputController : IExecutable
    {
        #region Fields

        private readonly IInputProxy _input;

        #endregion


        #region Properties

        internal IInputProxy Input => _input;

        #endregion


        #region ClassLifeCycles

        internal InputController(IInputProxy input)
        {
            _input = input;
        }

        #endregion


        #region Methods

        public void Execute(float deltaTime)
        {
            _input.GetAxisOnChanged();
            _input.GetKeyPressed();
        }

        #endregion
    }
}
