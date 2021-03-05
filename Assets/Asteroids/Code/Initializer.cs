namespace Asteroids
{
    internal sealed class Initializer
    {
        #region ClassLifeCycles

        internal Initializer(Controllers controller, GameData gameData)
        {
            var playerInitialized = new PlayerInitializer(gameData.Player);
            controller.AddController(playerInitialized.PlayerController);

            var cameraInitialized = new CameraInitializer(gameData.Camera, playerInitialized.PlayerController.TargetPosition);
            controller.AddController(cameraInitialized.CameraController);
        }

        #endregion
    }
}
