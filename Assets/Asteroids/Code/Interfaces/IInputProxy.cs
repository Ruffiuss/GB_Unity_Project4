using UnityEngine;
using System;


namespace Asteroids
{
    public interface IInputProxy
    {
        event Action<float, float, float> AxisOnChange;
        event Action<bool> MainFireOnPressed;
        event Action<bool> AccelerationOnChange;
        event Action<Vector3> MouseAxisOnChange;
        void GetAxisOnChanged(float deltaTime);
        void GetMouseAxis();
        void GetKeyPressed();
    }
}