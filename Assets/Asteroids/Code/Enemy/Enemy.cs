using UnityEngine;


namespace Asteroids
{
    internal abstract class Enemy : MonoBehaviour
    {
        #region Properties

        internal Health Health { get; private set; }

        #endregion


        #region Methods

        internal static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));

            enemy.Health = hp;

            return enemy;
        }

        internal void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

        #endregion
    }
}