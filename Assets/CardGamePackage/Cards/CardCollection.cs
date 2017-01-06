using System;
using System.Collections.Generic;
using CardGamePackage.Interfaces;
using UnityEngine;

namespace CardGamePackage.Cards
{
    /// <summary>
    /// Represents a collection of game cards derived from List<int/>
    /// </summary>
    public class CardCollection : List<int>, ICardCollection
    {
        private static readonly CardBase[] AllCards = Resources.LoadAll<CardBase>("Cards");

        /// <summary>
        /// Construct an empty CardBase collection.
        /// </summary>
        public CardCollection()
        {
        }

        /// <summary>
        /// Construct a new collection containing any number of card indices.
        /// </summary>
        public CardCollection(bool shuffle = false, params int[] collection)
        {
            this.AddRange(collection);
        }

        /// <summary>
        /// Construct a new collection containing any number of CardBase objects.
        /// </summary>
        public CardCollection(bool shuffle = false, params CardBase[] collection)
        {
            foreach (var card in collection)
                this.Add(Array.IndexOf(AllCards, card));

            if(shuffle)
                this.Shuffle();
        }

        public ICardDisplayInformation GetInfo(int i, bool hidden = false)
        {
            var index = this[i];
            return AllCards[index].GetInfo(hidden);
        }

        public ICommand Effect(int i)
        {
            var index = this[i];
            return AllCards[index].Effect;
        }

        public bool IsEmpty
        {
            get { return this.Count == 0; }
        }

        public void MoveCardTo(ICardCollection other, int index)
        {
            try
            {
                other.Add(this[index]);
                this.RemoveAt(index);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void MoveCardTo(ICardCollection other, int index, int insertIndex)
        {
            try
            {
                other.Insert(insertIndex, this[index]);
                this.RemoveAt(index);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}