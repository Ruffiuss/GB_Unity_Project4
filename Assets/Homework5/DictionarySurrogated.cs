using System.Collections.Generic;
using System.Runtime.Serialization;
using System;
using UnityEngine;


namespace Assets.Homework5
{
    [Serializable]
    [DataContract(Name = "Dictionary")]
    public sealed class DictionarySurrogated<T1, T2>
    {
        [DataMember]
        public List<TKeySerializable<T1, T2>> Keys;

        #region Extensions

        public override string ToString() => $"(KeysCount = {Keys.Count} FirstValueOfFirstKey = {Keys[0].Values[0]})";

        #endregion
    }

    [Serializable]
    public sealed class TKeySerializable<TK, TV>
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