using UnityEngine;


namespace Assets.Homework5.UnitFactories
{
    public class JsonParser<T>
    {
        public T Load(string path)
        {
            return JsonUtility.FromJson<T>(path);
        }
    }
}