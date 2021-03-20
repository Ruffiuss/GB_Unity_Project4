using UnityEngine;


namespace Asteroids
{
    internal sealed class GameObjectVisualBuilder : GameObjectBuilder
    {
        #region ClassLifeCycles

        public GameObjectVisualBuilder(GameObject gameObject) : base(gameObject) { }

        #endregion


        #region Methods

        public GameObjectVisualBuilder Name(string name)
        {
            _gameObject.name = name;
            return this;
        }

        public GameObjectVisualBuilder Sprite(Sprite sprite)
        {
            var component = _gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            return this;
        }

        public GameObjectVisualBuilder SpriteColor(Color color)
        {
            var component = _gameObject.GetOrAddComponent<SpriteRenderer>();
            component.color = color;
            return this;
        }

        public GameObjectVisualBuilder LayerSortingOrder(int order)
        {
            var component = _gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sortingOrder = order;
            return this;
        }

        public GameObjectVisualBuilder Scale(float x, float y)
        {
            var component = _gameObject.GetOrAddComponent<Transform>();
            component.localScale = new Vector3(x, y);
            return this;
        }

        #endregion
    }
}