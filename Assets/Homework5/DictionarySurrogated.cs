using System.Collections.Generic;
using System.Runtime.Serialization;
using System;


namespace Assets.Homework5
{
    [Serializable]
    [DataContract(Name = "Dictionary")]
    public sealed class DictionarySurrogated<T1, T2>
    {
        [DataMember]
        public List<TKeySerializable<T1, T2>> Keys;
        [DataMember]
        public List<T2> Values;
        [DataMember]
        public KeyValuePair<T1, T2>[] KeyValuePairs;



        #region Extensions

        public override string ToString() => $"(KeysCount = {Keys.Count} ValuesCount = {Values.Count})";

        #endregion
    }

    [Serializable]
    public sealed class TKeySerializable<TK, TV>
    {
        public TK KeySerializable;
        public List<TV> ValuesSerializable;

        public TKeySerializable(TK key, int valueCount = 0)
        {
            KeySerializable = key;
            ValuesSerializable = new List<TV>(valueCount);
        }

        public void AddValue(TV value)
        {
            ValuesSerializable.Add(value);
        }
    }
}