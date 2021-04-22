namespace Asteroids
{
    internal sealed class Initializer
    {
        #region ClassLifeCycles

        internal Initializer(Controllers controller, GameData gameData)
        {
            var inputInitialized = new InputController(new PCInput());
            controller.AddController(inputInitialized);

            var shipProvidersPool = new ShipProviderPool(gameData.Ship.Provider);

            var shipWeaponFactory = new ShipWeaponFactory(
                gameData.ShipWeapon,
                new ShipWeaponBulletsPool(gameData.ShipWeapon.Bullet));

            var shipFactory = new ShipInitializer(
                gameData.Ship,
                shipProvidersPool,
                shipWeaponFactory.GetShipWeapon);

            controller.AddController(shipFactory.CreateShipFromData(gameData.Ship));

            var playerInitialized = new PlayerInitializer(shipFactory.GetShip, gameData.Player, inputInitialized.Input);
            controller.AddController(playerInitialized.PlayerController);

            var cameraInitialized = new CameraInitializer(gameData.Camera, shipFactory.GetShip);
            controller.AddController(cameraInitialized.CameraController);

            var scoreSystem = new ScoreController(new ScoreInterpreter());

            IEnemyFactory factory = new AsteroidFactory();
            var createdEnemy = factory.Create(new Health(100.0f, 100.0f));
            scoreSystem.AddSource(createdEnemy); // temporary solution
            createdEnemy.ProviderDestroyed += scoreSystem.WathForSourceDestroy; // temporary solution

            scoreSystem.AddSource(shipFactory.GetShip); // temporary solution

            controller.AddController(new UIInitializer(gameData.UIData, scoreSystem).CreateUIFromData());
        }

        #endregion
    }
}