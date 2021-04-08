using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Asteroids
{
    internal sealed class UIController : IController
    {
        #region Fields

        private ICommand _showScore;
        private ICommand _showHealth;
        private ICommand _undoCommand;

        private readonly GameObject _provider;
        private readonly Dictionary<string, Dictionary<string, Text>> _elements;
        private readonly List<ICommand> _oldCommands = new List<ICommand>();

        #endregion


        #region ClassLifeCycles

        internal UIController(GameObject gameObject, Dictionary<string, List<Text>> elements)
        {
            _provider = gameObject;

            // ShowRecievedElements(elements);

            _elements = new Dictionary<string, Dictionary<string, Text>>();
            foreach (var element in elements)
            {
                _elements.Add(element.Key, new Dictionary<string, Text>());
                foreach (var value in element.Value)
                {
                    _elements[element.Key].Add(value.gameObject.name, value);
                }
            }

            DefineCommands(_elements);

            // ShowParsedElements();
        }

        #endregion


        #region Methods

        private void DefineCommands(Dictionary<string, Dictionary<string, Text>> elements)
        {
            _undoCommand = new UndoCommand(_oldCommands);

            foreach (var element in elements)
            {
                if (element.Key.Equals("UserInfo"))
                {
                    foreach (var textElement in element.Value)
                    {
                        switch (textElement.Key)
                        {
                            case "Score":
                                _showScore = new ShowText(textElement.Value);
                                break;
                            case "Health":
                                _showHealth = new ShowText(textElement.Value);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void ShowRecievedElements(Dictionary<string, List<Text>> elements)
        {
            foreach (var element in elements)
            {
                Debug.Log($"Key:{element.Key}, Values:");
                foreach (var value in element.Value)
                {
                    Debug.Log($"{value.text}");
                    Debug.Log(new string('-', 20));
                }
            }
            Debug.Log(new string('*', 20));
        }

        private void ShowParsedElements()
        {
            foreach (var key in _elements)
            {
                Debug.Log(key.Key);
                foreach (var value in key.Value)
                {
                    Debug.Log($"key-{value.Key}, value-{value.Value.text}");
                }
            }
        }

        internal void ChangeScore(string value)
        {
            _showScore.Perform();
            _oldCommands.Add(_showScore);
            _elements["UserInfo"]["Score"].text = $"Score : {value}";
        }

        #endregion
    }
}