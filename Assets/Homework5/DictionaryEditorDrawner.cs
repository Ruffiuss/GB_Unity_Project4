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
        #region UnityMethods

        public override void OnInspectorGUI()
        {
            DictionaryTest myTarget = (DictionaryTest)target;

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