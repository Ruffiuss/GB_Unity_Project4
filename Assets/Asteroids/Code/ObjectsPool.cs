using UnityEngine;
using System.Collections.Generic;

namespace Asteroids
{
    internal sealed class ObjectsPool : IPool<GameObject>
    {
        #region Fields

        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _object;

        #endregion


        #region ClassLifeCycles

        internal ObjectsPool(GameObject go)
        {
            _object = go;
        }

        #endregion


        #region Methods

        public void Push(GameObject go)
        {
            _stack.Push(go);
            go.SetActive(false);
        }

        public GameObject Pop()
        {
            GameObject go;

            if (_stack.Count == 0) go = Object.Instantiate(_object);
            else go = _stack.Pop();

            go.SetActive(true);

            return go;
        }

        #endregion
    }
}
