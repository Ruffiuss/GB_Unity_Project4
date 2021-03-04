namespace Asteroids
{
	internal sealed class GameLoader : MonoBehavior
	{
		#region Fields

		[SerializeField] private GameData _gameData;

		private Controllers _controllers;
		private GameExecuter _executer;

		#endregion


		#region UnityMethods

		private void Awake()
		{
			_controllers = new Controllers();
			new Initializer(_controllers, _gameData);
			_executer = new GameExecuter(_controllers);
		}

		#endregion
	}
}