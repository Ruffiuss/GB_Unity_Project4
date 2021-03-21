using System.Collections.Generic;

namespace Assets.Homework5
{
    public sealed class DictionaryProxy<T1, T2>
    {
        public Dictionary<T1, T2> Dictionary;
        public DictionaryProxy(Dictionary<T1, T2> dict)
        {
            Dictionary = dict;
        }
    }
}