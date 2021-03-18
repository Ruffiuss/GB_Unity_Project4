namespace Asteroids
{
    internal sealed class Initializer
    {
        #region ClassLifeCycles

        internal Initializer(Controllers controller, GameData gameData)
        {
             
            var inputInitialized = new InputController(new PCInput());
            controller.AddController(inputInitialized);

            ServiceLocator.SetService(new ShipProviderPool(gameData.Ship.Provider));

            var shipWeaponFactory = new ShipWeaponFactory(
                gameData.ShipWeapon,
                new ShipWeaponBulletsPool(gameData.ShipWeapon.Bullet));

            var shipFactory = new ShipInitializer(
                gameData.Ship,
                ServiceLocator.Resolve<ShipProviderPool>(),
                shipWeaponFactory.GetShipWeapon);

            controller.AddController(shipFactory.CreateShipFromData(gameData.Ship));

            var playerInitialized = new PlayerInitializer(shipFactory.GetShip, gameData.Player, inputInitialized.Input);
            controller.AddController(playerInitialized.PlayerController);

            var cameraInitialized = new CameraInitializer(gameData.Camera, shipFactory.GetShip);
            controller.AddController(cameraInitialized.CameraController);

            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(100.0f, 100.0f));
        }

        #endregion
    }
}