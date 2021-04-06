using UnityEngine;
using System;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "UI", menuName = "Data/UI")]
    internal class UIData : ScriptableObject
    {
        public GameObject Provider;
    }
}