using UnityEngine;


namespace Asteroids
{
    internal sealed class GameLoader : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameData _gameData;

        private Controllers _controllers;
        private float _deltaTime;
        private float _fixedDeltaTime;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _controllers = new Controllers();
            new Initializer(_controllers, _gameData);
        }

        private void Update()
        {
            _deltaTime = Time.deltaTime;
            _controllers.Execute(_deltaTime);
        }

        private void LateUpdate()
        {
            _fixedDeltaTime = Time.fixedDeltaTime;
            _controllers.LateExecute(_fixedDeltaTime);
        }

        #endregion
    }
}