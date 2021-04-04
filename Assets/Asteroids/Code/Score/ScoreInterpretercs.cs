using System;


namespace Asteroids
{
    internal sealed class ScoreInterpreter
    {
        #region Methods

        internal string ToInterpreted(long number)
        {
            if ((number < 0) || (number > 999999999)) throw new ArgumentOutOfRangeException(nameof(number), "Value can`t be more than 999`999`999");
            if (number >= 1000000) return $"{number/1000000}M";
            if (number >= 1000) return $"{number/1000}K";
            if (number < 1) return string.Empty;
            throw new ArgumentOutOfRangeException(nameof(number));
        }

        #endregion
    }
}