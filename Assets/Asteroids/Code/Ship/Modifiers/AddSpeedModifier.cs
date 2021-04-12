namespace Asteroids
{
    internal sealed class AddSpeedModifier : ShipModifier
    {
        #region Fields

        private readonly float _speedModifier;

        #endregion


        #region ClassLifeCycles

        public AddSpeedModifier(Ship ship, float modifyValue)
            : base(ship)
        {
            _speedModifier = modifyValue;
        }

        #endregion


        #region Methods

        public override void Handle()
        {
            _ship.SpeedMultiplier = _speedModifier;
            base.Handle();
        }

        #endregion
    }
}