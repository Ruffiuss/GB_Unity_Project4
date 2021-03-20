using UnityEngine;
using System.Collections.Generic;


namespace Asteroids
{
    internal sealed class ShipWeaponBulletsPool : IPool<GameObject>
    {
        #region Fields

        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _object;
        private readonly GameObject _root;

        #endregion


        #region ClassLifeCycles

        internal ShipWeaponBulletsPool(GameObject go)
        {
            _root = new GameObject("Bullets_Root");
            _object = go;
        }

        #endregion


        #region Methods

        public GameObject Pop()
        {
            GameObject go;

            if (_stack.Count == 0)
            {
                go = new GameObjectBuilder().Visual.Name("Bullet").Sprite(Resources.Load<Sprite>("Bullet/bullet_sprite")).LayerSortingOrder(2).SpriteColor(Color.red).Scale(8.0f, 8.0f)
                    .Physics.SetMass2D(_object.GetComponent<Rigidbody2D>().mass).IsKinematic(false).IsTrigger2D(false).AddView<BulletView>();
                go.transform.parent = _root.transform;                
            }
            else go = _stack.Pop();

            go.SetActive(true);
            go.GetComponent<Rigidbody2D>().isKinematic = false;
            go.GetComponent<BulletView>().ProviderDestroyed += Push;

            return go;
        }

        public void Push(GameObject go)
        {
            _stack.Push(go);
            go.SetActive(false);
            go.GetComponent<Rigidbody2D>().isKinematic = true;
        }

        #endregion
    }
}