using UnityEngine;


namespace Asteroids
{
    internal sealed class PlayerModel
    {
        #region Fields

        private PlayerData _data;

        #endregion


        #region Properties

        internal IPlayerContorllable Ship => _data.Ship;

        #endregion


        #region ClassLifeCycle

        internal PlayerModel(IPlayerContorllable ship, PlayerData data)
        {
            _data = (PlayerData)data.Clone();
            _data.Ship = ship;
        }

        #endregion
    }
}