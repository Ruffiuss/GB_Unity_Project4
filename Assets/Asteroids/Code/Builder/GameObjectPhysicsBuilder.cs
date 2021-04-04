using UnityEngine;


namespace Asteroids
{
    internal sealed class GameObjectPhysicsBuilder : GameObjectBuilder
    {
        #region ClassLifeCycles

        public GameObjectPhysicsBuilder(GameObject gameObject) : base(gameObject) { }

        #endregion


        #region Methods

        public GameObjectPhysicsBuilder SetMass2D(float mass)
        {
            var component = _gameObject.GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            return this;
        }

        public GameObjectPhysicsBuilder IsKinematic(bool value)
        {
            var component = _gameObject.GetOrAddComponent<Rigidbody2D>();
            component.isKinematic = value;
            return this;
        }

        public GameObjectPhysicsBuilder IsTrigger2D(bool value)
        {
            var component = _gameObject.GetOrAddComponent<BoxCollider2D>();
            component.isTrigger = value;
            return this;
        }

        public GameObjectPhysicsBuilder AddView<T>() where T : MonoBehaviour
        {
            _gameObject.GetOrAddComponent<T>();
            return this;
        }

        #endregion
    }
}