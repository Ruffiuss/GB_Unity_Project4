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
        [SerializeField] private string _uiDataPath;

        private PlayerData _playerData;
        private CameraData _cameraData;
        private ShipData _shipData;
        private ShipWeaponData _shipWeaponData;
        private UIData _uiData;

        #endregion


        #region Properties

        public PlayerData Player
        {
            get
            {
                if(_playerData == null)
                {
                    _playerData = Load<PlayerData>(DataAddresses.ROOT + _playerDataPath);
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
                    _cameraData = Load<CameraData>(DataAddresses.ROOT + _playerDataPath);
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
                    _shipData = Load<ShipData>(DataAddresses.ROOT + _shipDataPath);
                }

                return _shipData;
            }
        }

        public ShipWeaponData ShipWeapon
        {
            get
            {
                if (_shipWeaponData == null)
                {
                    _shipWeaponData = Load<ShipWeaponData>(DataAddresses.ROOT + _shipWeaponDataPath);
                }

                return _shipWeaponData;
            }
        }

        public UIData UIData
        {
            get
            {
                if (_uiData == null)
                {
                    _uiData = Load<UIData>(DataAddresses.ROOT + _uiDataPath);
                }

                return _uiData;
            }
        }

        #endregion


        #region Methods

        private T Load<T>(string path) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(path, null));

        #endregion
    }
}