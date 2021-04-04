namespace Asteroids
{
    internal sealed class AddHealthModifier : ShipModifier
    {
        #region Fields

        private readonly float _healthModifier;

        #endregion


        #region ClassLifeCycles

        public AddHealthModifier(Ship ship, float modifyValue)
            : base(ship)
        {
            _healthModifier = modifyValue;
        }

        #endregion


        #region Methods

        public override void Handle()
        {
            if (_ship.Health < _healthModifier)
            {
                _ship.ChangeHealth(_healthModifier);
            }
            base.Handle();
        }

        #endregion
    }
}