using System.Collections.Generic;
using UnityEngine;
using System;


namespace Assets.Homework5
{
    [Serializable]
    public class DictionarySerializeLoader : MonoBehaviour
    {
        public Dictionary<int, float> example = new Dictionary<int, float>() { { 1, 2.0f }, { 22, 11.0f } };
        public DictionarySurrogated<int, float> Dictionary;
        public List<TKeySerializable<int, float>> Keys;

        private void Awake()
        {
            var serializer = new DictionaryContractSerializerExample<int, float>(example);
        }
    }
}