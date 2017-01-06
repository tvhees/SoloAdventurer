using Model.Player;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class PlayerView : MonoBehaviour
    {
        private Text[] textPanels;
        private IAdventurerPlayer player;

        private void Start()
        {
            textPanels = GetComponentsInChildren<Text>();
        }

        public void SetPlayer(IAdventurerPlayer player)
        {
            this.player = player;
        }

        private void Update()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            var strings = new[]
            {
                "Movement", player.Movement.ToString(),
                "Influence", player.Influence.ToString(),
                "Attack", player.Attack.ToString(),
                "Block", player.Block.ToString()
            };

            for (var i = 0; i < strings.Length; i++)
            {
                if (i >= textPanels.Length)
                    break;
                textPanels[i].text = strings[i];
            }
        }
    }
}