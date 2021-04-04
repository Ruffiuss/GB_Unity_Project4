namespace Asteroids
{
    internal class ShipModifier
    {
        #region Fields

        protected Ship _ship;
        protected ShipModifier _next;

        #endregion


        #region ClassLifeCycles

        public ShipModifier(Ship ship)
        {
            _ship = ship;
        }

        #endregion


        #region Methods

        public void Add(ShipModifier modifier)
        {
            if (_next != null)
            {
                _next.Add(modifier);
            }
            else
            {
                _next = modifier;
            }
        }

        public virtual void Handle() => _next?.Handle();

        #endregion
    }
}