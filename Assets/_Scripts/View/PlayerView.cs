using Model.Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using View.ComponentTypes;

namespace View
{
    public class PlayerView : MonoBehaviour
    {
        private IAdventurer player;
        private ViewType<Text> texts;
        private UnityAction<Text, int> textUpdate;
        private string[] playerResources;

        private void Awake()
        {
            texts = gameObject.AddComponent<TextView>();
            textUpdate = (txt, i) => { txt.text = playerResources[i]; };
        }

        public void SetPlayer(IAdventurer player)
        {
            this.player = player;
        }

        private void Update()
        {
            playerResources = player.Resources;
            texts.UpdateView(playerResources.Length, textUpdate);
        }
    }
}