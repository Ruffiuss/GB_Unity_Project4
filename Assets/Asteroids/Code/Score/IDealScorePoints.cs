using System;


namespace Asteroids
{
    internal interface IDealScorePoints : IScoreSource
    {
        void PointsForDestroy(int score);
    }
}