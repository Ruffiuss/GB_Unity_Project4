namespace Asteroids
{
    internal sealed class DoNothing : ICommand
    {
        #region Properties

        public bool Successed { get; private set; }

        #endregion


        #region Methods

        public bool Perform()
        {
            Successed = true;
            return Successed;
        }

        public void Undo()
        {
        }

        #endregion
    }
}