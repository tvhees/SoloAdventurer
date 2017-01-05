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
        private ICardCollection collection;
        private ICardGamePlayer owner;
        private Button[] buttons;
        private Image[] images;
        private Text[] textPanels;

        #region MonoBehaviour

        protected virtual void Start()
        {
            buttons = GetComponentsInChildren<Button>();
            images = GetComponentsInChildren<Image>();
            textPanels = GetComponentsInChildren<Text>();
            AssignButtonListeners();
        }

        private void Update()
        {
            for (var i = 0; i < buttons.Length; i++)
            {
                UpdateButtonView(i);
            }
        }

        #endregion MonoBehaviour

        /// <summary>
        /// Assign listener action for each button attached as a child of this object.
        /// </summary>
        private void AssignButtonListeners()
        {
            for (var i = 0; i < buttons.Length; i++)
            {
                var config = new CommandConfig(collection, i, owner);
                buttons[i].onClick.AddListener(() => ExecuteEffect(config));
            }
        }

        /// <summary>
        /// Listener action that pushes card effects to the stack.
        /// </summary>
        private void ExecuteEffect(ICommandConfig config)
        {
            var effect = collection.Effect(config.SourceIndex);
            CommandStack.Execute(effect.Create(config));
        }

        /// <summary>
        /// Pass reference to list of items that will be displayed
        /// </summary>
        public virtual void SetCollection(ICardCollection collection, ICardGamePlayer owner)
        {
            this.collection = collection;
            this.owner = owner;
        }

        /// <summary>
        /// Display a button if it corresponds to a non-null item, deactivate it otherwise.
        /// </summary>
        private void UpdateButtonView(int i)
        {
            if (i < collection.Count)
                DisplayItem(i);
            else
                buttons[i].gameObject.SetActive(false);
        }

        /// <summary>
        /// Activate a button and display an item's name on it.
        /// </summary>
        protected virtual void DisplayItem(int i)
        {
            buttons[i].gameObject.SetActive(true);
            buttons[i].interactable = !this.isHidden;
            var info = collection.GetInfo(i, this.isHidden);
            images[i].color = info.Colour;
            textPanels[i].text = info.Name;
        }
    }
}