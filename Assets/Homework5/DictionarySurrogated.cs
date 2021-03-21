using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Assets.Homework5
{
    [DataContract(Name = "Dictionary")]
    public sealed class DictionarySurrogated<T1, T2>
    {
        [DataMember]
        public Dictionary<T1, T2> dictionary;
    }
}