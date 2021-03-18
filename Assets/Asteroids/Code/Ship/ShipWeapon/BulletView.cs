using System;
using UnityEngine;


namespace Asteroids
{
    internal sealed class BulletView : MonoBehaviour, IView
    {
        #region Properties

        public event Action<GameObject> ProviderDestroyed;

        #endregion


        #region UnityMethods

        public void OnCollisionEnter2D(Collision2D collision)
        {
            ProviderDestroyed.Invoke(gameObject);
        }

        private void OnDestroy()
        {
            ProviderDestroyed.Invoke(gameObject);
        }

        #endregion
    }
}