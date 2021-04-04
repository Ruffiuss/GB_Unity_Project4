using UnityEngine;


namespace Asteroids
{
    public static class Extensions
    {
        #region Methods

        public static T GetOrAddComponent<T>(this GameObject self) where T : Component
        {
            var result = self.GetComponent<T>();
            if (!result)
            {
                result = self.AddComponent<T>();
            }
            return result;
        }

        #endregion
    }
}