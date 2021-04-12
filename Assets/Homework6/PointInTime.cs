using UnityEngine;


namespace Homework6
{
    public sealed class PointInTime
    {
        #region Fields

        public Vector3 Position;
        public Vector3 Velocity;
        public Quaternion Rotation;
        public float AngularVelocity;

        #endregion


        #region ClassLifeCycles

        public PointInTime(Vector3 position, Quaternion rotation, Vector3 velocity, float angularVelocity)
        {
            Position = position;
            Velocity = velocity;
            AngularVelocity = angularVelocity;
            Rotation = rotation;
        }

        #endregion
    }
}