using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Assets.Homework5.UnitFactories
{
    public class AbstarctUnitFactory : MonoBehaviour
    {
        #region Fields

        public Units[] ParsedUnits;
        public List<IUnit> CreatedUnits = new List<IUnit>();
        private InfantryFactory infantryFactory = new InfantryFactory();
        private MagFactory magFactory = new MagFactory();

        public string JsonPath;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            string jsonString = File.ReadAllText(JsonPath);
            ParsedUnits = JsonHelper.FromJson<Units>("{\r\n    \"Items\": " + jsonString + "}");
        }

        private void Start()
        {

            foreach (var units in ParsedUnits)
            {
                IUnit unit = units.unit;
                switch (unit.Type)
                {
                    case "mag":
                        CreatedUnits.Add(magFactory.CreateUnit(unit.Health));
                        break;
                    case "infantry":
                        CreatedUnits.Add(infantryFactory.CreateUnit(unit.Health));
                        break;
                    default:
                        break;
                }
                
            }

            foreach (var unit in CreatedUnits)
            {
                Debug.Log($"\nType - {unit.Type}, Health - {unit.Health}\n");
            }
        }

        #endregion
    }
}