﻿using UnityEngine;
using System;


namespace Asteroids
{
    internal sealed class PCInput : IInputProxy
    {
        #region Properties

        public event Action<float, float, float> AxisOnChange;
        public event Action<bool> MainFireOnPressed;
        public event Action<bool> ReloadWeaponOnPressed;
        public event Action<bool> AccelerationOnChange;
        public event Action<Vector3> MouseAxisOnChange;

        #endregion


        #region Methods

        public void GetAxisOnChanged(float deltaTime)
        {
            AxisOnChange.Invoke(Input.GetAxis(InputManager.HORIZONTAL_AXIS), Input.GetAxis(InputManager.VERTICAL_AXIS), deltaTime);
        }

        public void GetKeyPressed()
        {
            if (Input.GetKeyDown(InputManager.PLAYER_FIRE1))
            {
                MainFireOnPressed.Invoke(true);
            }
            if (Input.GetKeyDown(InputManager.PLAYER_RELOAD_WEAPON))
            {
                ReloadWeaponOnPressed.Invoke(true);
            }

            if (Input.GetKeyDown(InputManager.PLAYER_ACCELERATE))
            {
                AccelerationOnChange.Invoke(true);
            }
            else if (Input.GetKeyUp(InputManager.PLAYER_ACCELERATE))
            {
                AccelerationOnChange.Invoke(false);
            }
        }

        public void GetMouseAxis()
        {
            MouseAxisOnChange.Invoke(Input.mousePosition);
        }

        #endregion
    }
}
