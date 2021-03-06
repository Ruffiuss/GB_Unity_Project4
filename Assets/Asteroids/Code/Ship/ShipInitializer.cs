using UnityEngine;


namespace Asteroids
{
    internal sealed class ShipInitializer
    {
        #region Fields

        private Ship _ship;

        #endregion


        #region Properties

        internal Ship Controller => _ship;

        #endregion


        #region ClassLifeCycles

        internal ShipInitializer(ShipData data)
        {
            var spawnedShip = Object.Instantiate(data.Provider);
            var shipModel = new ShipModel(spawnedShip, data);

            var accelerationMove = new AccelerationMove(spawnedShip.transform, shipModel.Speed, shipModel.Acceleration);
            var rotationShip = new RotationShip(spawnedShip.transform);
            _ship = new Ship(accelerationMove, rotationShip, shipModel);
        }

        #endregion
    }
}