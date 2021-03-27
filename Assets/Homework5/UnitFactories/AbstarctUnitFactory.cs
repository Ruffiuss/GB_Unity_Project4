using System;
using UnityEngine;


namespace Assets.Homework5.UnitFactories
{
    public class AbstarctUnitFactory : MonoBehaviour
    {
        #region Fields

        public string JsonPath;

        public Unit[] unit;

        #endregion


        #region Methods

        private void Awake()
        {
            var a = new JsonParser<AbstarctUnitFactory>().Load(JsonPath);
            Debug.Log(a);
        }

        #endregion
    }
}