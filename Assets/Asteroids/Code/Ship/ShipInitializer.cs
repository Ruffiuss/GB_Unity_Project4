using UnityEngine;


namespace Asteroids
{
    internal sealed class ShipInitializer : IShipFactory
    {
        #region Fields

        private readonly ShipData _data;
        private readonly IPool<GameObject> _providersPool;
        private Ship _shipController;

        #endregion


        #region Properties

        public Ship GetShip => _shipController;

        #endregion


        #region ClassLifeCycles

        internal ShipInitializer(ShipData data, IPool<GameObject> providersPool)
        {
            _data = data;
            _providersPool = providersPool;
        }

        #endregion


        #region Methods

        public IController CreateShipFromData()
        {
            var spawnedShip =_providersPool.Pop();
            spawnedShip.AddComponent<ShipView>();

            var shipModel = new ShipModel(
                new ShipData()
                {
                    Provider = spawnedShip,
                    Speed = _data.Speed,
                    Acceleration = _data.Acceleration,
                    HP = _data.HP,
                    Force = _data.Force
                });

            var moveImplementation = new AccelerationMove(spawnedShip.transform, shipModel.Speed, shipModel.Acceleration);
            var rotationImplementation = new RotationShip(spawnedShip.transform);

            _shipController = new Ship(moveImplementation, rotationImplementation, shipModel);
            spawnedShip.GetComponent<IView>().ProviderDestroyed += _shipController.WatchToProviderDestroyed;

            _shipController.ReloadRequired += ReloadShipController;

            return _shipController;
        }

        public void ReloadShipController(GameObject provider, bool isRequired)
        {
            if (isRequired)
            {
                var newProvider = _providersPool.Pop();
                newProvider.AddComponent<ShipView>();

                var newModel = new ShipModel(new ShipData()
                {
                    Provider = newProvider,
                    Speed = _data.Speed,
                    Acceleration = _data.Acceleration,
                    HP = _data.HP,
                    Force = _data.Force
                });

                var moveImplementation = new AccelerationMove(newProvider.transform, newModel.Speed, newModel.Acceleration);
                var rotationImplementation = new RotationShip(newProvider.transform);

                _shipController.ReloadShip(moveImplementation, rotationImplementation, newModel);

                newProvider.GetComponent<IView>().ProviderDestroyed += _shipController.WatchToProviderDestroyed;
            }
            else
            {
                provider.GetComponent<IView>().ProviderDestroyed -= _shipController.WatchToProviderDestroyed;
                _providersPool.Push(provider);
            }             
        }



        #endregion
    }
}