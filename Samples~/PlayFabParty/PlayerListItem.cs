using PlayFab.Party;
using UnityEngine;
using UnityEngine.UI;

namespace PartyTestApp
{
    public class PlayerListItem : MonoBehaviour
    {
        public Text nameEl;
        public Text entityIDEl;
        public Text chatStateEl;
        public Text muteButtonText;
        public PlayFabPlayer pfPlayer;
        public ShowPlayerDetailsButton showDetailsButtonBehavior;

        public void Mute()
        {
            if (muteButtonText.text == "Mute")
            {
                pfPlayer.IsMuted = true;
                muteButtonText.text = "Unmute";
            }
            else
            {
                pfPlayer.IsMuted = false;
                muteButtonText.text = "Mute";
            }
        }
    }
}
