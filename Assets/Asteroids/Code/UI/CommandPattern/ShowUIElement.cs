using UnityEngine;


namespace Asteroids
{
    internal sealed class ShowUIElement : ICommand
    {
        #region Fields

        private readonly Canvas _canvasElement;

        #endregion


        #region Properties

        public bool Successed { get; private set; }

        #endregion


        #region ClassLifeCycles

        internal ShowUIElement(Canvas element)
        {
            _canvasElement = element;
        }

        #endregion


        #region Methods

        public bool Perform()
        {
            _canvasElement.enabled = true;
            Successed = true;
            return Successed;
        }

        public void Undo()
        {
            _canvasElement.enabled = false;
        }

        #endregion
    }
}