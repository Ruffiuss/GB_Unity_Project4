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
        public float SpeedMultiplier { protected get; set; }

        #endregion


        #region ClassLifeCycles

        internal MoveTransform(Transform transform, float speed, float speedMultiplier = 1.0f)
        {
            _transform = transform;
            Speed = speed;
            SpeedMultiplier = speedMultiplier;
        }

        #endregion


        #region Methods

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed * SpeedMultiplier;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _transform.localPosition += _move;
        }

        #endregion
    }
}
