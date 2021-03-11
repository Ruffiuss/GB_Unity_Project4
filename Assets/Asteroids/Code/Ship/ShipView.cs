using UnityEngine;
using System;


namespace Asteroids
{
    public class ShipView : MonoBehaviour, IDamagable
    {
        #region Properties

        public event Action<Collision2D> Collision = delegate (Collision2D collider) { };
        public event Action<GameObject, bool> ProviderDestroyed = delegate (GameObject provider, bool isDestroyed) { };

        #endregion


        #region UnityMethods

        private void OnCollisionEnter2D(Collision2D other)
        {
            Collision.Invoke(other);
        }

        private void OnDestroy()
        {
            ProviderDestroyed.Invoke(gameObject, true);
        }

        #endregion
    }
}