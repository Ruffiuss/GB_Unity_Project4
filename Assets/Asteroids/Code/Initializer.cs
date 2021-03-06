namespace Asteroids
{
    internal sealed class Initializer
    {
        #region ClassLifeCycles

        internal Initializer(Controllers controller, GameData gameData)
        {
            var inputInitialized = new InputController(new PCInput());
            controller.AddController(inputInitialized);

            var shipInitialized = new ShipInitializer(gameData.Ship);
            controller.AddController(shipInitialized.Controller);

            var playerInitialized = new PlayerInitializer(shipInitialized.Controller, gameData.Player, inputInitialized.Input);
            controller.AddController(playerInitialized.PlayerController);

            var cameraInitialized = new CameraInitializer(gameData.Camera, shipInitialized.Controller);
            controller.AddController(cameraInitialized.CameraController);
        }

        #endregion
    }
}
