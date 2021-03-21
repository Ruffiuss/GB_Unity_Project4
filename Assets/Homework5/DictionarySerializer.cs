using System;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Homework5
{
    [Serializable]
    [CustomEditor(typeof(DictionaryTest))]
    public class DictionarySerializer : Editor
    {
        #region Fields

        private string[] _toolbarItems = new string[] { "Add Pair" };

        #endregion


        #region UnityMethods

        public override void OnInspectorGUI()
        {
            DictionaryTest myTarget = (DictionaryTest)target;

            GUILayout.Toolbar(0, _toolbarItems);

            if (myTarget.Dictionary.Count.Equals(0))
            {
                DefineDictionary(ref myTarget.Dictionary);
            }

            int keyParsed;
            string valueParsed;

            foreach (var key in myTarget.Dictionary.Keys)
            {
                keyParsed = key;
                EditorGUILayout.IntSlider(keyParsed, 0, 100);
                valueParsed = myTarget.Dictionary[key];
                EditorGUILayout.TextField("Value", valueParsed);
            }
        }

        #endregion


        #region Methods

        private void DefineDictionary(ref Dictionary<int, string> dicitonary, int key = 0, string value = "none")
        {
            dicitonary = new Dictionary<int, string>() { { key, value } };
        }

        #endregion
    }
}