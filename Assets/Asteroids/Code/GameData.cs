using System.IO;
using UnityEngine;


namespace Asteroids
{
	[CreateAssetMenu(fileName = "Game", menuName = "Data/Game")]
	public sealed class GameData : ScriptableObject
	{
		#region Fields

		[SerializeField] private string _playerDataPath;

		private PlayerData _playerData;

		#endregion


		#region Properties

		public PlayerData Player
		{
			get
			{
				if(_playerData == null)
				{
					_playerData = Load<PlayerData>(GlobalProperties.DATA_PATH + _playerDataPath);
				}

				return _playerData;
			}
		}

		#endregion


		#region Methods

		private T Load<T>(string path) where T : Object =>
			Resources.Load<T>(Path.ChangeExtension(path, null));

		#endregion
	}
}