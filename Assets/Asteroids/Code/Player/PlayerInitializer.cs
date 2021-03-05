using UnityEngine;


namespace Asteroids
{
    internal sealed class PlayerInitializer
    {
        #region Properties

        public Player PlayerController { get; }

        #endregion


        #region ClassLifeCycles

        internal PlayerInitializer(PlayerData data)
        {
            var spawnedShip = Object.Instantiate(data.Provider);
            PlayerController = new Player(new PlayerModel(spawnedShip, data));
        }

        #endregion
    }
}