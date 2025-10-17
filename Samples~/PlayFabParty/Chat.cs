using PlayFab.Party;
using UnityEngine;
using UnityEngine.UI;

namespace PartyTestApp
{
    public class Chat : MonoBehaviour
    {
        public Text chatMessages;
        public PlayerList playerList;
        public InputField chatInputText;

        // Start is called before the first frame update
        void Start()
        {
            var pfMM = PlayFabMultiplayerManager.Get();
            pfMM.OnChatMessageReceived += LocalPlayer_OnChatMessageReceived;
        }

        private void LocalPlayer_OnChatMessageReceived(object sender, PlayFabPlayer from, string message, ChatMessageType type)
        {
            Player player = playerList.GetPlayerByEntityId(from.EntityKey);
            if (player != null)
            {
                chatMessages.text += "\n" + player.name + ":" + message;
            }
        }

        public void SendChatMessage()
        {
            var pfMM = PlayFabMultiplayerManager.Get();
            pfMM.SendChatMessage(chatInputText.text, pfMM.RemotePlayers);
        }

        public void SendChatMessageToAllPlayers()
        {
            var pfMM = PlayFabMultiplayerManager.Get();
            pfMM.SendChatMessageToAllPlayers(chatInputText.text);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
