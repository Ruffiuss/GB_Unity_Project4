using UnityEngine;


namespace Asteroids
{
    internal sealed class PlayerModel
    {
        #region Fields

        private PlayerData _data;

        #endregion


        #region Properties

        internal float Speed => _data.Speed;
        internal float Acceleration => _data.Acceleration;
        internal float Force => _data.Force;
        internal float Health => _data.HP;
        internal Transform ProvidePosition => _data.Provider.transform;

        #endregion


        #region ClassLifeCycle

        internal PlayerModel(GameObject provider, PlayerData data)
        {
            _data = (PlayerData)data.Clone();
            _data.Provider = provider;
        }

        #endregion


        #region Methods

        internal void ChangeHealth(float value)
        {
            _data.HP += value;
        }

        #endregion
    }
}