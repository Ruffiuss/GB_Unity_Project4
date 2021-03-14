namespace Asteroids
{
    internal sealed class Initializer
    {
        #region ClassLifeCycles

        internal Initializer(Controllers controller, GameData gameData)
        {
            var inputInitialized = new InputController(new PCInput());
            controller.AddController(inputInitialized);

            var poolProviders = new ObjectsPool(gameData.Ship.Provider);

            var shipFactory = new ShipInitializer(gameData.Ship, poolProviders);

            controller.AddController(shipFactory.CreateShipFromData());

            var playerInitialized = new PlayerInitializer(shipFactory.GetShip, gameData.Player, inputInitialized.Input);
            controller.AddController(playerInitialized.PlayerController);

            var cameraInitialized = new CameraInitializer(gameData.Camera, shipFactory.GetShip);
            controller.AddController(cameraInitialized.CameraController);

            //Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));

            //IEnemyFactory factory = new AsteroidFactory();
            //factory.Create(new Health(100.0f, 100.0f));
        }

        #endregion
    }
}
