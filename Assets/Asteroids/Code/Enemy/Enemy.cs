using System;
using UnityEngine;


namespace Asteroids
{
    internal abstract class Enemy : MonoBehaviour, IDealScorePoints, IView
    {
        #region Properties

        internal Health Health { get; private set; }

        public event Action<int> OnScoreChange;
        public event Action<GameObject> ProviderDestroyed;

        #endregion


        #region UnityMethods

        private void OnDestroy()
        {
            PointsForDestroy(5);
        }

        #endregion


        #region Methods

        internal static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));

            enemy.Health = hp;

            return enemy;
        }

        public void PointsForDestroy(int score)
        {
            OnScoreChange.Invoke(score);
            ProviderDestroyed.Invoke(gameObject);
        }

        internal void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

        #endregion
    }
}