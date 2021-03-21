using UnityEngine;


namespace Asteroids
{
    internal sealed class PlayerInitializer
    {
        #region Properties

        public Player PlayerController { get; }

        #endregion


        #region ClassLifeCycles

        internal PlayerInitializer(IPlayerContorllable ship, PlayerData data, IInputProxy input)
        {
            var model = new PlayerModel(ship, data);
            PlayerController = new Player(model, input);
        }

        #endregion
    }
}