using UnityEngine.UI;
using System.Collections.Generic;


namespace Asteroids
{
    internal sealed class UndoCommand : ICommand
    {
        #region Fields

        private readonly List<ICommand> _commands;

        #endregion


        #region Properties

        public bool Successed { get; private set; }

        #endregion


        #region ClassLifeCycles

        internal UndoCommand(List<ICommand> commands)
        {
            _commands = commands;
        }

        #endregion


        #region Methods

        public bool Perform()
        {
            if (_commands.Count > 0)
            {
                ICommand latestCommand = _commands[_commands.Count - 1];

                if (latestCommand.Successed)
                {
                    latestCommand.Undo();

                    _commands.RemoveAt(_commands.Count - 1);
                    Successed = true;
                }
            }
            else Successed = false;
            return Successed;
        }

        public void Undo()
        {
        }

        #endregion
    }
}
