using System.IO;
using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Game", menuName = "Data/Game")]
    internal sealed class GameData : ScriptableObject
    {
        #region Fields

        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _cameraDataPath;
        [SerializeField] private string _shipDataPath;
        [SerializeField] private string _shipWeaponDataPath;

        private PlayerData _playerData;
        private CameraData _cameraData;
        private ShipData _shipData;
        private ShipWeaponData _shipWeaponData;

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

        public ShipData Ship
        {
            get
            {
                if (_shipData == null)
                {
                    _shipData = Load<ShipData>(GlobalProperties.DATA_PATH + _shipDataPath);
                }

                return _shipData;
            }
        }

        public ShipWeaponData ShipWeaponData
        {
            get
            {
                if (_shipWeaponData == null)
                {
                    _shipWeaponData = Load<ShipWeaponData>(GlobalProperties.DATA_PATH + _shipWeaponDataPath);
                }

                return _shipWeaponData;
            }
        }

        #endregion


        #region Methods

        private T Load<T>(string path) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(path, null));

        #endregion
    }
}