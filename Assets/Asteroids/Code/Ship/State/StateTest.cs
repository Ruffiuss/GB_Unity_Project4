using UnityEngine;


namespace Asteroids
{
    internal sealed class StateTest : MonoBehaviour
    {
        private void Start()
        {
            Context c = new Context(new IdleShipState());

            c.Request();
            c.Request();
            c.Request();
            c.Request();
        }
    }
}