using System.Collections.Generic;
using UnityEngine;


namespace Assets.Homework5
{
    public class DictionarySerializerLoader : MonoBehaviour
    {
        public Dictionary<int, float> example = new Dictionary<int, float>() { { 1, 2.0f } };

        private void Awake()
        {
            var serializer = new DictionaryContractSerializerExample<int, float>(example);
        }
    }
}