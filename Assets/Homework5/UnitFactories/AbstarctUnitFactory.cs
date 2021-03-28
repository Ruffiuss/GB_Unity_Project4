using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Assets.Homework5.UnitFactories
{
    public class AbstarctUnitFactory : MonoBehaviour
    {
        #region Fields

        public string JsonPath;

        #endregion


        #region Methods

        private void Awake()
        {
            string jsonString = File.ReadAllText(JsonPath);
            var unitA = new Unit() { type = "mag", health = "100" };
            var unitB = new Unit() { type = "infantry", health = "150" };
            var unitC = new Unit() { type = "mag", health = "50" };
            Units[] abc = { new Units() { unit = unitA }, new Units() { unit = unitB }, new Units() { unit = unitC } };
            
            Debug.Log(JsonUtility.ToJson(unitA));
            Debug.Log(JsonUtility.ToJson(unitB));
            Debug.Log(JsonUtility.ToJson(unitC));
            Debug.Log(JsonHelper.ToJson(abc));
            Units[] Units = JsonHelper.FromJson<Units>("{\r\n    \"Items\": " + jsonString + "}");
            Debug.Log(Units);
        }

        #endregion
    }
}