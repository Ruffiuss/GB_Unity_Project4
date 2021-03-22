using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Assets.Homework5
{    
    public class DictionaryTest : MonoBehaviour
    {
        public Dictionary<int, string> Dictionary = new Dictionary<int, string>() { { 0, "text1" }, { 1, "text2" } };
        public DictionaryXMLData Data = new DictionaryXMLData();

        private void Awake()
        {
            if (!Directory.Exists(Path.Combine("Assets/Homework5")))
            {
                Directory.CreateDirectory("Assets/Homework5");
            }
            Data.Save(Dictionary, "Assets/Homework5/dictsave.xml");
        }
    }
}