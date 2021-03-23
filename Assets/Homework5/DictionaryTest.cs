using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Assets.Homework5
{    
    public class DictionaryTest : MonoBehaviour
    {
        public Dictionary<int, string> Dictionary;
        public DictionaryXMLData Data;

        private void Awake()
        {
            Dictionary = Data.Load("Assets/Homework5/dictsave.xml");
            foreach (var pair in Dictionary)
            {
                Debug.Log($"{pair.Key}, {pair.Value}");
            }
        }
    }
}