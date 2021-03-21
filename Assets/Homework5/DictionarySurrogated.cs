using System.Collections.Generic;
using System.Runtime.Serialization;
using System;
using UnityEngine;


namespace Assets.Homework5
{
    [DataContract(Name = "Dictionary")]
    [Serializable]
    public sealed class DictionarySurrogated<T1, T2>
    {
        [DataMember]
        public List<TKeySerializable<T1, T2>> Keys;
    }

    [Serializable]
    public struct TKeySerializable<TK, TV>
    {

        [SerializeField] public TK KeySerializable;
        [SerializeField] public List<TV> ValuesSerializable;

        public List<TV> Values => ValuesSerializable;

        public TKeySerializable(TK key, TV value, int valueCount = 1)
        {
            KeySerializable = key;
            ValuesSerializable = new List<TV>(valueCount);
            AddValue(value);
        }

        public void AddValue(TV value)
        {
            ValuesSerializable.Add(value);
        }
    }
}