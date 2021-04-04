using UnityEngine;


namespace Assets.Homework5.GunDecorator
{
    internal sealed class Aim : IAim
    {
        #region Properties

        public Transform AimPosition { get; }
        public GameObject AimInstance { get; }

        #endregion


        #region ClassLifeCycles

        public Aim(Transform aimPosition, GameObject aimInstance)
        {
            AimPosition = aimPosition;
            AimInstance = aimInstance;
        }

        #endregion
    }
}