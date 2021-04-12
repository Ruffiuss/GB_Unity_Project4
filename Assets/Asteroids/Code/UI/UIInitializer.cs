using System.Collections.Generic;
using UnityEngine.UI;


namespace Asteroids
{
    internal sealed class UIInitializer : IUIFactory
    {
        #region Fields

        private UIData _data;
        private ScoreController _scoreController;

        #endregion


        #region Properties

        public UIController GetUIController { get; private set; }

        #endregion


        #region ClassLifeCycles

        public UIInitializer(UIData data, ScoreController scoreController)
        {
            _data = data;
            _scoreController = scoreController;
        }

        ~UIInitializer()
        {
            // move to cleanup method
            // _scoreController.OnScoreChange -= GetUIController.ChangeScore;
        }

        #endregion


        #region Methods

        public IController CreateUIFromData()
        {
            var createdUI = UnityEngine.Object.Instantiate(_data.Provider);

            Dictionary<string, List<Text>> uiElements = new Dictionary<string, List<Text>>();

            for (int i = 0; i < createdUI.transform.childCount; i++)
            {
                if (createdUI.transform.GetChild(i).tag.Equals("UIElement"))
                {
                    var key = createdUI.transform.GetChild(i).name;
                    var element = createdUI.transform.GetChild(i).transform;
                    for (int i2 = 0; i2 < element.childCount; i2++)
                    {
                        if (!uiElements.ContainsKey(key))
                        {
                            var list = new List<Text>();
                            list.Add(element.GetChild(i2).GetComponent<Text>());
                            uiElements.Add(key, list);
                        }
                        else
                        {
                            uiElements[key].Add(element.GetChild(i2).GetComponent<Text>());
                        }
                    }
                }
            }
            GetUIController = new UIController(createdUI, uiElements);
            _scoreController.OnScoreChange += GetUIController.ChangeScore;
            return GetUIController;
        }

        #endregion
    }
}