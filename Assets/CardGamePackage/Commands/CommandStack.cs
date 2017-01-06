using System.Collections.Generic;
using CardGamePackage.Interfaces;

namespace CardGamePackage.Commands
{
    /// <summary>
    /// Static holder for ICommand Stack object.
    /// </summary>
    public static class CommandStack
    {
        private static readonly Stack<ICommand> Stack = new Stack<ICommand>();

        public static bool CanUndo {
            get { return !(Stack.IsEmpty() || Stack.Peek().IsPermanent); }
        }

        /// <summary>
        /// Execute a command and then push it to the top of the stack.
        /// </summary>
        public static void Execute(ICommand command)
        {
            command.Execute();
            Stack.Push(command);
        }

        /// <summary>
        /// Pop the most recent command from the stack and Undo it.
        /// </summary>
        public static void Undo()
        {
            Stack.Pop().Undo();
        }
    }
}
