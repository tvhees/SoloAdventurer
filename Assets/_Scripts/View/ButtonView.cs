using CardGamePackage.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ButtonView : MonoBehaviour
    {
        public Button UndoButton;

        private void Update()
        {
            UndoButton.interactable = !CommandStack.IsEmpty;
        }

        public void Undo()
        {
            CommandStack.Undo();
        }
    }
}