using System;
using UnityEngine;


namespace Assets.Homework5.UnitFactories
{
    [Serializable]
    public class Unit
    {
        [SerializeField] public string type;
        [SerializeField] public string health;
    }
}