using UnityEngine;


namespace Asteroids
{
    internal static class GlobalProperties
    {
        internal const string DATA_PATH = "Data/";
    }

    internal static class InputManager
    {
        internal const string HORIZONTAL_AXIS = "Horizontal"; 
        internal const string VERTICAL_AXIS = "Vertical";
        internal const KeyCode PLAYER_FIRE1 = KeyCode.Mouse0;
        internal const KeyCode PLAYER_ACCELERATE = KeyCode.LeftShift;
    }
}