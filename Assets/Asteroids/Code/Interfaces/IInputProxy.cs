using UnityEngine;
using System;


namespace Asteroids
{
    public interface IInputProxy
    {
        event Action<float, float> AxisOnChange;
        event Action<bool> MainFireOnPressed;
        event Action<bool> AccelerationOnChange;
        event Action<Vector3> MouseAxisOnChange;
        void GetAxisOnChanged();
        void GetMouseAxis();
        void GetKeyPressed();
    }
}