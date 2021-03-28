using System;
using UnityEngine;


namespace Assets.Homework5.UnitFactories
{
    [Serializable]
    public class Unit : IUnit
    {
        [SerializeField] public string type;
        [SerializeField] public string health;

        public string Type => type;

        public int Health
        {
            get
            {
                if (int.TryParse(health, out int result))
                {
                    return result;
                }
                return 0;
            } 
        }
    }
}