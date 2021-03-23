using System;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Homework5
{
    [Serializable]
    [CustomEditor(typeof(DictionaryTest))]
    public class DictionaryEditorDrawner : Editor
    {
        #region Fields

        public DictionaryXMLData SerializedDictionary = new DictionaryXMLData();

        #endregion
        #region UnityMethods

        public override void OnInspectorGUI()
        {
            DictionaryTest myTarget = (DictionaryTest)target;

            myTarget.Dictionary = SerializedDictionary.Load("Assets/Homework5/dictsave.xml");
            if (myTarget.Dictionary.Equals(null))
            {
                DefineDictionary(myTarget.Dictionary);
                myTarget.Data = SerializedDictionary;
            }

            DrawDictionaryFields(myTarget);

        }

        #endregion


        #region Methods

        private void DefineDictionary(Dictionary<int, string> dicitonary, int key = 0, string value = "none")
        {
            dicitonary = new Dictionary<int, string>() { { key, value } };
            SerializedDictionary.Save(dicitonary, "Assets/Homework5/dictsave.xml");
        }

        private void DrawDictionaryFields(DictionaryTest currentTarget)
        {
            int keyParsed;
            string valueParsed;

            foreach (var key in currentTarget.Dictionary.Keys)
            {
                keyParsed = key;
                EditorGUILayout.IntSlider(keyParsed, 0, 100);
                valueParsed = currentTarget.Dictionary[key];
                EditorGUILayout.TextField("Value", valueParsed);
            }
        }

        #endregion
    }
}