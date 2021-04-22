namespace Asteroids
{
    internal sealed class ShipStateController : IExecutable
    {
        #region Fields

        private Context _currentContext;

        #endregion


        #region ClassLifeCycles

        internal ShipStateController()
        {
            _currentContext = new Context(new IdleShipState());
        }

        #endregion


        #region Methods

        public void Execute(float deltaTime)
        {
            _currentContext.DoLoop();
        }

        #endregion
    }
}