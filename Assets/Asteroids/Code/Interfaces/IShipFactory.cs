using UnityEngine;


namespace Asteroids
{
    internal interface IShipFactory : IFactory
    {
        Ship CreateShipFromData(ShipData data);
        Ship UpdateShipModel(IPlayable controller, IPool<GameObject> provider);
    }
}