using System.Collections.Generic;
using System.Xml;

namespace Assets.Homework5
{
    public sealed class DictionaryXMLData
    {
        #region Methods

        public void Save(Dictionary<int,string> dictionary, string path = "")
		{
			var xmlDoc = new XmlDocument();

			XmlNode rootNode = xmlDoc.CreateElement("SerializableDictionary");
			xmlDoc.AppendChild(rootNode);

			var dictionaryElement = xmlDoc.CreateElement("KeyValuePair");
			dictionaryElement.SetAttribute("key_type", typeof(int).ToString());
			dictionaryElement.SetAttribute("value_type", typeof(string).ToString());
			rootNode.AppendChild(dictionaryElement);

            foreach (var key in dictionary.Keys)
            {
				var KeyValuePair = xmlDoc.CreateElement("KeyValuePair");
				KeyValuePair.SetAttribute("key", key.ToString());
				KeyValuePair.SetAttribute("value", dictionary[key].ToString());
				dictionaryElement.AppendChild(KeyValuePair);
			}

			xmlDoc.Save(path);
		}

        #endregion
    }
}