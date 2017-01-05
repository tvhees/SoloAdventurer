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

        public static void Execute(ICommand command)
        {
            command.Execute();
            Stack.Push(command);
        }

        public static void Undo()
        {
            if (Stack.Peek().IsPermanent)
                return;
            Stack.Pop().Undo();
        }

        public static bool IsEmpty {
            get { return Stack.Count == 0; }
        }
    }
}
