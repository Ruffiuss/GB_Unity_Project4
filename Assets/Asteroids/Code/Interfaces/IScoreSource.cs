using System;


namespace Asteroids
{
    public interface IScoreSource
    {
        event Action<int> OnScoreChange;
    }
}