using System;
using CardGamePackage.Commands;
using CardGamePackage.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using View.ComponentTypes;

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
        private ViewType<Button> buttons;
        private ViewType<Image> images;
        private ViewType<Text> texts;

        private UnityAction<Button> buttonUpdate;
        private UnityAction<Image, int> imageUpdate;
        private UnityAction<Text, int> textUpdate;

        private void Awake()
        {
            buttons = gameObject.AddComponent<ButtonView>();
            images = gameObject.AddComponent<ImageView>();
            texts = gameObject.AddComponent<TextView>();

            buttonUpdate = button => button.interactable = !this.isHidden;
            imageUpdate = (img, i) => img.color = Collection.GetInfo(i, isHidden).Colour;
            textUpdate = (txt, i) => txt.text = Collection.GetInfo(i, isHidden).Name;
        }

        protected virtual void Start()
        {
            buttons.DoEach(AssignListener());
        }

        /// <summary>
        /// Make a button event trigger execution of the corresponding Card's command.
        /// </summary>
        /// <returns></returns>
        private UnityAction<Button, int> AssignListener()
        {
            return (button, i) =>
            {
                var config = new CommandConfig(Collection, i, Owner);
                button.onClick.AddListener(() => ExecuteEffect(config));
            };
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
        /// Pass reference to list of items that will be displayed
        /// </summary>
        public void SetCollection(ICardCollection collection, ICardPlayer owner)
        {
            this.Collection = collection;
            this.Owner = owner;
        }

        private void Update()
        {
            var size = Collection.Count;
            buttons.UpdateView(size, buttonUpdate);
            images.UpdateView(size, imageUpdate);
            texts.UpdateView(size, textUpdate);
        }
    }
}