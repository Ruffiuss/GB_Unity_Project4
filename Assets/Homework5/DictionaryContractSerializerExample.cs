using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using UnityEngine;


namespace Assets.Homework5
{
    public sealed class DictionaryContractSerializerExample<T1, T2>
    {
        private readonly Dictionary<T1, T2> dict;
        public DictionaryContractSerializerExample(Dictionary<T1, T2> dictionary) { dict = dictionary; Main(); }

        public void Main()
        {
            try
            {
                WriteObject<T1, T2>("DictionaryContractSerializer.xml", dict);
                ReadObject<T1, T2>("DictionaryContractSerializer.xml");
            }
            catch (SerializationException serExc)
            {
                Debug.Log("Serialization Failed");
                Debug.Log(serExc.Message);
            }
            catch (Exception exc)
            {
                Debug.Log($"The serialization operation failed: {exc.Message} StackTrace: {exc.StackTrace}");
            }
            finally
            {
                Debug.Log("Press <Enter> to exit....");
                Console.ReadLine();
            }
        }

        public static void WriteObject<T1, T2>(string fileName, Dictionary<T1, T2> dictionary)
        {
            FileStream writer = new FileStream(fileName, FileMode.Create);
            DataContractSerializer ser =
                new DataContractSerializer(typeof(Dictionary<T1, T2>));
            ser.WriteObject(writer, dictionary);
            writer.Close();
        }

        public static void ReadObject<T1, T2>(string fileName)
        {
            Debug.Log("Deserializing an instance of the object.");
            FileStream fs = new FileStream(fileName,
            FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(Dictionary<T1, T2>));

            // Deserialize the data and read it from the instance.
            Dictionary<T1, T2> deserializedDictionary =
                (Dictionary<T1, T2>)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();
            foreach (var item in deserializedDictionary)
            {
                Debug.Log($"KeyValuePair:{item.Key},{item.Value}\n");
            }
        }
    }
}