using UnityEngine;
using System;


namespace Asteroids
{
    public class ShipView : MonoBehaviour, IDamagable
    {
        #region Properties

        public event Action<Collision2D> Collision = delegate (Collision2D collider) { };
        public event Action<GameObject> ProviderDestroyed = delegate (GameObject provider) { };

        #endregion


        #region UnityMethods

        private void OnCollisionEnter2D(Collision2D other)
        {
            Collision.Invoke(other);
        }

        private void OnDestroy()
        {
            ProviderDestroyed.Invoke(gameObject);
        }

        #endregion


        #region Methods

        public void ProviderDestroyedMessage()
        {
            Debug.Log($"{name} now destroyed");
        }

        #endregion
    }
}