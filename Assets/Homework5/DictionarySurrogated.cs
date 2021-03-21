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
        public TKeySerializable<T1, T2> Key;
    }

    [Serializable]
    public struct TKeySerializable<TK, TV>
    {

        public TK KeySerializable;
        public TV ValuesSerializable;

        public TKeySerializable(TK key, TV value)
        {
            KeySerializable = key;
            ValuesSerializable = value;
        }
    }
}