using CardGamePackage.Commands;
using CardGamePackage.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    /// <summary>
    /// CollectionView implementation for CardBase items.
    /// </summary>
    public class CardView : MonoBehaviour
    {
        [SerializeField] private bool isHidden;
        protected ICardCollection Collection;
        protected ICardPlayer Owner;
        private Button[] buttons;
        private Image[] images;
        private Text[] textPanels;

        protected virtual void Start()
        {
            buttons = GetComponentsInChildren<Button>();
            images = GetComponentsInChildren<Image>();
            textPanels = GetComponentsInChildren<Text>();
            AssignButtonListeners();
        }

        /// <summary>
        /// Pass reference to list of items that will be displayed
        /// </summary>
        public void SetCollection(ICardCollection collection, ICardPlayer owner)
        {
            this.Collection = collection;
            this.Owner = owner;
        }

        private void Update()
        {
            for (var i = 0; i < buttons.Length; i++)
            {
                UpdateButtonView(i);
            }
        }

        /// <summary>
        /// Assign listener action for each button attached as a child of this object.
        /// </summary>
        private void AssignButtonListeners()
        {
            for (var i = 0; i < buttons.Length; i++)
            {
                var config = new CommandConfig(Collection, i, Owner);
                buttons[i].onClick.AddListener(() => ExecuteEffect(config));
            }
        }

        /// <summary>
        /// Listener action that pushes card effects to the stack.
        /// </summary>
        private void ExecuteEffect(ICommandConfig config)
        {
            var effect = Collection.Effect(config.SourceIndex);
            CommandStack.Execute(effect.Create(config));
        }

        /// <summary>
        /// Display a button if it corresponds to a non-null item, deactivate it otherwise.
        /// </summary>
        private void UpdateButtonView(int i)
        {
            if (i < Collection.Count)
                DisplayItem(i);
            else
                buttons[i].gameObject.SetActive(false);
        }

        /// <summary>
        /// Activate a button and display an item's name on it.
        /// </summary>
        private void DisplayItem(int i)
        {
            buttons[i].gameObject.SetActive(true);
            buttons[i].interactable = !this.isHidden;
            var info = Collection.GetInfo(i, this.isHidden);
            images[i].color = info.Colour;
            textPanels[i].text = info.Name;
        }
    }
}