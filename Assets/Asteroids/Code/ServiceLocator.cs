using System;
using UnityEngine;
using System.Collections.Generic;


namespace Asteroids
{
    internal static class ServiceLocator
    {
        #region Fields

        private static readonly Dictionary<Type, object> _serviceContainer = new Dictionary<Type, object>();

        #endregion


        #region Methods

        internal static void SetService<T>(T value) where T : class
        {
            var key = typeof(T);
            if (!_serviceContainer.ContainsKey(key))
            {
                _serviceContainer[key] = value;
            }
        }

        internal static T Resolve<T>()
        {
            var key = typeof(T);
            if (_serviceContainer.ContainsKey(key))
            {
                return (T)_serviceContainer[key];
            }

            return default;
        }

        #endregion
    }
}