using System.Collections.Generic;
using System.Xml;

namespace Assets.Homework5
{
    public sealed class DictionaryXMLData
    {
		private int keyCache;
		private string valueCache;

        #region Methods

        public void Save(Dictionary<int,string> dictionary, string path = "")
		{
			var xmlDoc = new XmlDocument();

			XmlNode rootNode = xmlDoc.CreateElement("SerializableDictionary");
			xmlDoc.AppendChild(rootNode);

			var dictionaryTypes = xmlDoc.CreateElement("Types");
			dictionaryTypes.SetAttribute("key_type", typeof(int).ToString());
			dictionaryTypes.SetAttribute("value_type", typeof(string).ToString());
			rootNode.AppendChild(dictionaryTypes);

            foreach (var pair in dictionary.Keys)
            {
				var dictionaryElement = xmlDoc.CreateElement("KeyValuePair");
				dictionaryElement.SetAttribute("key", pair.ToString());
				dictionaryElement.SetAttribute("value", dictionary[pair].ToString());
				dictionaryTypes.AppendChild(dictionaryElement);
			}

			xmlDoc.Save(path);
		}

		public Dictionary<int, string> Load(string path = "")
        {
			var result = new Dictionary<int, string>();

			using (var reader = new XmlTextReader(path))
            {
				while (reader.Read())
                {
					var element = "KeyValuePair";
                    if (reader.IsStartElement(element))
                    {
						if (reader.MoveToAttribute("key"))
						{
							keyCache = int.Parse(reader.Value);
						}
						reader.MoveToAttribute("value");
						valueCache = reader.Value;
						result.Add(keyCache, valueCache);
						reader.MoveToElement();
					}
				}
            }

			return result;
        }

        #endregion
    }
}