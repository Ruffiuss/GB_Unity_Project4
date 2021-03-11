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

            return new Ship(shipModel);
        }

        public Ship UpdateShipModel(IPlayable controller, IPool<GameObject> provider)
        {
            var spawnedShip = provider;
            return new Ship(new ShipModel(
                new ShipData()
                    {
                        Provider = spawnedShip,
                        Speed = data.Speed,
                        Acceleration = data.Acceleration,
                        HP = data.HP,
                        Force = data.Force
                    });
                ));
        }

        #endregion
    }
}