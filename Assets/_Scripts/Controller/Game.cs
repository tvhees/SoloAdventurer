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
        [SerializeField] private Adventurer adventurer;
        [SerializeField] private CardView deckView;
        [SerializeField] private CardView handView;
        [SerializeField] private CardView playView;
        [SerializeField] private CardView discardView;
        [SerializeField] private PlayerView playerView;

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
            adventurer.Initialise();
            deckView.SetCollection(adventurer.Deck, adventurer);
            handView.SetCollection(adventurer.Hand, adventurer);
            playView.SetCollection(adventurer.Play, adventurer);
            discardView.SetCollection(adventurer.Discard, adventurer);
            playerView.SetPlayer(adventurer);
        }
    }
}