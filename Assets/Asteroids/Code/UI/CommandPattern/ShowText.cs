using UnityEngine.UI;


namespace Asteroids
{
    internal sealed class ShowText : ICommand
    {
        #region Fields

        private readonly Text _textElement;

        #endregion


        #region Properties

        public bool Successed { get; private set; }

        #endregion


        #region ClassLifeCycles

        internal ShowText(Text textElement)
        {
            _textElement = textElement;
            _textElement.enabled = false;
            _textElement.text = "";
        }

        #endregion


        #region Methods

        public bool Perform()
        {
            _textElement.enabled = true;
            Successed = true;
            return Successed;
        }

        public void Undo()
        {
            _textElement.enabled = false;
        }

        #endregion
    }
}