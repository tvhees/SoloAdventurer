using CardGamePackage.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    /// <summary>
    /// Class for displaying and listening to Unity UI buttons.
    /// </summary>
    public class ButtonView : MonoBehaviour
    {
        public Button UndoButton;

        private void Update()
        {
            UndoButton.interactable = CommandStack.CanUndo;
        }

        public void Undo()
        {
            CommandStack.Undo();
        }
    }
}