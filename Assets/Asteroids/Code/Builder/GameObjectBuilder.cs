using UnityEngine;


namespace Asteroids
{
    internal class GameObjectBuilder
    {
        #region Fields

        protected GameObject _gameObject;

        #endregion


        #region Properties

        public GameObjectBuilder() => _gameObject = new GameObject();
        public GameObjectVisualBuilder Visual => new GameObjectVisualBuilder(_gameObject);
        public GameObjectPhysicsBuilder Physics => new GameObjectPhysicsBuilder(_gameObject);
        protected GameObjectBuilder(GameObject gameObject) => _gameObject = gameObject;

        #endregion


        #region Methods

        public static implicit operator GameObject(GameObjectBuilder builder)
        {
            return builder._gameObject;
        }

        #endregion
    }
}