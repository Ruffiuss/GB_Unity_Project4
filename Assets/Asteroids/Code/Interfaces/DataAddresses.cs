using UnityEngine;


namespace Asteroids
{
    internal static class DataAddresses
    {
        internal const string ROOT = "Data/";
    }

    internal static class InputManager
    {
        internal const string HORIZONTAL_AXIS = "Horizontal"; 
        internal const string VERTICAL_AXIS = "Vertical";
        internal const KeyCode PLAYER_FIRE1 = KeyCode.Mouse0;
        internal const KeyCode PLAYER_ACCELERATE = KeyCode.LeftShift;
    }
}