namespace Asteroids
{
    internal sealed class Health
    {
        #region Fields

        public float Max { get; }
        public float Current { get; private set; }

        #endregion


        #region ClassLifeCycles

        internal Health(float max, float current)
        {
            Max = max;
            Current = current;
        }

        #endregion


        #region Methods

        internal void ChangeCurrentHealth(float hp)
        {
            Current = hp;
        }

        #endregion
    }
}
