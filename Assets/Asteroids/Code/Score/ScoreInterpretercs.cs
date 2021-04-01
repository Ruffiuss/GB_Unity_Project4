namespace Asteroids
{
    internal sealed class ScoreInterpreter
    {
        #region Methods

        internal string ToInterpreted(int number)
        {
            if (number >= 1000)
            {
                return "1k";
            }
            return "0";
        }

        #endregion
    }
}