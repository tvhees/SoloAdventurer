using System.Collections.Generic;
using CardGamePackage.Interfaces;
using Model.Player;
using UnityEngine;
using View;

namespace Controller
{
    /// <summary>
    /// Scene object to hold instance and references for a Game.
    /// </summary>
    public class Game : MonoBehaviour
    {
        private ICardGamePlayer player;
        [SerializeField] private CardView deckView;
        [SerializeField] private CardView handView;
        [SerializeField] private CardView discardView;

        public List<ScriptableObject> Stack;

        private void Awake()
        {
            CreatePlayer();
        }

        /// <summary>
        /// Make a new player and link models to views.
        /// </summary>
        private void CreatePlayer()
        {
            player = new Player();
            deckView.SetCollection(player.Deck, player);
            handView.SetCollection(player.Hand, player);
            discardView.SetCollection(player.Discard, player);
        }
    }
}