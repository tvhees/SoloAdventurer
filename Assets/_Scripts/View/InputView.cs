using CardGamePackage.Commands;
using CardGamePackage.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using View.ComponentTypes;

namespace View
{
    /// <summary>
    /// Class for displaying and listening to Unity UI buttons.
    /// </summary>
    public class InputView : MonoBehaviour
    {
        public ScriptableCommand[] Commands;
        private ViewType<Button> inputs;
        private ViewType<Text> texts;
        private UnityAction<Text, int> textUpdate;
        protected ICardPlayer Owner;

        private void Awake()
        {
            inputs = gameObject.AddComponent<ButtonView>();
            texts = gameObject.AddComponent<TextView>();

            textUpdate = (txt, i) => txt.text = Commands[i].name;
        }

        private void Start()
        {
            inputs.DoEach(AssignListener());
        }

        /// <summary>
        /// Make a button event trigger execution of the corresponding Card's command.
        /// </summary>
        /// <returns></returns>
        private UnityAction<Button, int> AssignListener()
        {
            return (button, i) =>
            {
                var config = new CommandConfig(null, i, Owner);
                button.onClick.AddListener(() => ExecuteEffect(config));
            };
        }

        /// <summary>
        /// Listener action that pushes card effects to the stack.
        /// </summary>
        private void ExecuteEffect(ICommandConfig config)
        {
            var command = Commands[config.SourceIndex];
            CommandStack.Execute(command.Create(config));
        }

        private void Update()
        {
            inputs.UpdateView(Commands.Length);
            texts.UpdateView(Commands.Length, textUpdate);
        }

        /// <summary>
        /// Pass reference to list of items that will be displayed
        /// </summary>
        public void SetPlayer(ICardPlayer owner)
        {
            this.Owner = owner;
        }
    }
}