namespace Asteroids
{
	internal sealed class PlayerModel
	{
		#region Fields

		private readonly PlayerData _data;

		#endregion


		#region ClassLifeCycle

		internal PlayerModel(PlayerData data)
		{
			_data = data.Clone();
		}

		#endregion
	}
}