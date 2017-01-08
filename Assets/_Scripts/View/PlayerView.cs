using Model.Player;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class PlayerView : MonoBehaviour
    {
        private Text[] textPanels;
        private IAdventurer player;

        private void Start()
        {
            textPanels = GetComponentsInChildren<Text>();
        }

        public void SetPlayer(IAdventurer player)
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
                "Movement", player.Movement.Value.ToString(),
                "Influence", player.Influence.Value.ToString(),
                "Attack", player.Attack.Value.ToString(),
                "Block", player.Block.Value.ToString()
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