using System.IO;
using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Game", menuName = "Data/Game")]
    public sealed class GameData : ScriptableObject
    {
        #region Fields

        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _cameraDataPath;

        private PlayerData _playerData;
        private CameraData _cameraData;

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

        public CameraData Camera
        {
            get
            {
                if(_cameraData == null)
                {
                    _cameraData = Load<CameraData>(GlobalProperties.DATA_PATH + _playerDataPath);
                }

                return _cameraData;
            }
        }

        #endregion


        #region Methods

        private T Load<T>(string path) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(path, null));

        #endregion
    }
}