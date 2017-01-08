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
        [SerializeField] private ViewType<Button> buttons;
        [SerializeField] private ViewType<Image> images;
        [SerializeField] private ViewType<Text> texts;

        private void Awake()
        {
            buttons = gameObject.AddComponent<ButtonView>();
            images = gameObject.AddComponent<ImageView>();
            texts = gameObject.AddComponent<TextView>();
        }

        protected virtual void Start()
        {
            buttons.DoEach(AssignListener());
        }

        /// <summary>
        /// Make a button event trigger execution of the corresponding Card's command.
        /// </summary>
        /// <returns></returns>
        private Action<Button, int> AssignListener()
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
            buttons.UpdateView(size, (but) => but.interactable = !this.isHidden);
            images.UpdateView(size,
                (img, i) =>
                {
                    if (i >= size) return;
                    img.color = Collection.GetInfo(i, this.isHidden).Colour;
                });
            texts.UpdateView(size,
                (txt, i) =>
                {
                    if (i >= size) return;
                    txt.text = Collection.GetInfo(i, this.isHidden).Name;
                });
        }
    }
}