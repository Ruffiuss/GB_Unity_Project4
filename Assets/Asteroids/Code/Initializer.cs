namespace Asteroids
{
	internal sealed class Initializer()
	{
		#region ClassLifeCycles

		internal Initializer(Controllers controller, GameData gameData)
		{
			var playerInitialized = new PlayerInitializer(gameData.Player);
		}

		#endregion
	}
}
