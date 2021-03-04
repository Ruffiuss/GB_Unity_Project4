namespace Asteroids
{
	internal sealed class PlayerInitializer()
	{
		#region Fields

		private readonly Player _playerController;

		#endregion


		#region Properties

		public Player PlayerController {get => _playerController; }


		#region ClassLifeCycles

		internal PlayerInitializer(PlayerData data)
		{
			_playerController = new PlayerController(new PlayerModel(data));
		}

		#endregion
	}
}