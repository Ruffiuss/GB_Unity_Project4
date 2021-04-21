using UnityEngine;


namespace Asteroids
{
    internal sealed class ShipInitializer : SpawnLogger, IShipFactory
    {
        #region Fields

        private readonly ShipData _data;
        private readonly IPool<GameObject> _providersPool;
        private readonly IShipWeapon _weapon;

        private readonly ConsoleDisplayLogInfo _logger; // temporary solution

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

            _logger = new ConsoleDisplayLogInfo();  // temporary solution
        }

        #endregion


        #region Methods

        public IController CreateShipFromData(ShipData data)
        {
            var spawnedShip =_providersPool.Pop();
            
            SpawnLogInfo(_logger, spawnedShip.gameObject.name, spawnedShip.transform.position); // temporary solution


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
            spawnedShip.GetComponent<IDamagable>().ProviderDestroyed += GetShip.WatchForProviderDestroyed;
            spawnedShip.GetComponent<IDamagable>().Collision += GetShip.CollisionHandler; // temporary solution

            GetShip.ReloadRequired += ReloadShipController;
            

            return GetShip;
        }

        public void ReloadShipController(GameObject provider, bool isRequired)
        {
            if (isRequired)
            {
                var newProvider = _providersPool.Pop();

                SpawnLogInfo(_logger, newProvider.gameObject.name, newProvider.transform.position); // temporary solution

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

                newProvider.GetComponent<IDamagable>().ProviderDestroyed += GetShip.WatchForProviderDestroyed;
                newProvider.GetComponent<IDamagable>().Collision += GetShip.CollisionHandler; // temporary solution
            }
            else
            {
                provider.GetComponent<IDamagable>().ProviderDestroyed -= GetShip.WatchForProviderDestroyed;
                provider.GetComponent<IDamagable>().Collision -= GetShip.CollisionHandler; // temporary solution
                _providersPool.Push(provider);
            }             
        }

        internal override void SpawnLogInfo(IDealLogInfo value, string name, Vector3 position)
        {            
            value.SpawnLogInfo(new InfoSpawnLog(position, name));
        }

        #endregion
    }
}