namespace Asteroids
{
    internal interface IEnemyFactory
    {
        Enemy Create(Health hp);
    }
}