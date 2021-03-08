using UnityEngine;


namespace Asteroids
{
    internal sealed class ShipInitializer : IShipFactory
    {
        #region Methods

        public Ship CreateShipFromData(ShipData data)
        {
            var spawnedShip = Object.Instantiate(data.Provider);
            spawnedShip.AddComponent<ShipView>();

            var shipModel = new ShipModel(
                new ShipData()
                {
                    Provider = spawnedShip,
                    Speed = data.Speed,
                    Acceleration = data.Acceleration,
                    HP = data.HP,
                    Force = data.Force
                });

            var moveImplementation = new AccelerationMove(spawnedShip.transform, shipModel.Speed, shipModel.Acceleration);
            var rotationImplementation = new RotationShip(spawnedShip.transform);
            return new Ship(moveImplementation, rotationImplementation, shipModel);
        }

        #endregion
    }
}