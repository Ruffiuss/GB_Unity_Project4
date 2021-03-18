using UnityEngine;
using System.Collections.Generic;


namespace Asteroids
{
    internal sealed class ShipWeaponBulletsPool : IPool<GameObject>
    {
        #region Fields

        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _object;

        #endregion


        #region ClassLifeCycles

        internal ShipWeaponBulletsPool(GameObject go)
        {
            _object = go;
        }

        #endregion


        #region Methods

        public GameObject Pop()
        {
            GameObject go;

            if (_stack.Count == 0)
            {
                go = Object.Instantiate(_object);
            }
            else go = _stack.Pop();

            go.SetActive(true);
            go.GetComponent<Rigidbody2D>().simulated = true;
            go.GetComponent<BulletView>().ProviderDestroyed += Push;

            return go;
        }

        public void Push(GameObject go)
        {
            go.GetComponent<BulletView>().ProviderDestroyed -= Push;
            _stack.Push(go);
            go.SetActive(false);
            go.GetComponent<Rigidbody2D>().simulated = false;
        }

        #endregion
    }
}