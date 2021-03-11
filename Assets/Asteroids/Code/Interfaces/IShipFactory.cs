using UnityEngine;


namespace Asteroids
{
    internal interface IShipFactory : IFactory
    {
        IController CreateShipFromData();
        void ReloadShipController(GameObject provider, bool isRequired);
        Ship GetShip { get; }
    }
}