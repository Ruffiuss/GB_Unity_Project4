using UnityEngine;


namespace Asteroids
{
    internal sealed class ShipInitializer : IShipFactory
    {
        #region Fields

        private readonly ShipData _data;
        private readonly IPool<GameObject> _providersPool;
        private readonly IShipWeapon _weapon;

        #endregion


        #region Properties

        public Ship GetShip { get; private set; }

        #endregion


        #region ClassLifeCycles

        internal ShipInitializer(ShipData data, IPool<GameObject> providersPool, IShipWeapon weapon)
        {
            _data = data;
            _providersPool = providersPool;
            _weapon = weapon;
        }

        #endregion


        #region Methods

        public IController CreateShipFromData(ShipData data)
        {
            var spawnedShip =_providersPool.Pop();

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

            GetShip = new Ship(moveImplementation, rotationImplementation, _weapon, shipModel);
            spawnedShip.GetComponent<IView>().ProviderDestroyed += GetShip.WatchToProviderDestroyed;

            GetShip.ReloadRequired += ReloadShipController;

            return GetShip;
        }

        public void ReloadShipController(GameObject provider, bool isRequired)
        {
            if (isRequired)
            {
                var newProvider = _providersPool.Pop();

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

                GetShip.ReloadShip(moveImplementation, rotationImplementation, newModel);

                newProvider.GetComponent<IView>().ProviderDestroyed += GetShip.WatchToProviderDestroyed;
            }
            else
            {
                provider.GetComponent<IView>().ProviderDestroyed -= GetShip.WatchToProviderDestroyed;
                _providersPool.Push(provider);
            }             
        }

        #endregion
    }
}