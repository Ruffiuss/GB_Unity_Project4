using UnityEngine;


namespace Asteroids
{
    public class MoveTransform : IMove
    {
        #region Fields

        private Vector3 _move;
        private readonly Transform _transform;

        #endregion


        #region Properties

        public float Speed { get; protected set; }

        #endregion


        #region ClassLifeCycles

        internal MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }

        #endregion


        #region Methods

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _transform.localPosition += _move;
        }

        #endregion
    }
}
