using PlayFab.Party;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;

namespace PartyTestApp
{
    public class PlayerList : MonoBehaviour
    {
        public GameObject playerListItemPrefab;
        public InputField languageCodeInputEl;
        public InputField voiceLevelInputEl;
        public Text playerDetailsentityIDEl;

        private List<Player> players;

        private float offset = 0;

        // Start is called before the first frame update
        void Start()
        {
            players = new List<Player>();
            var pfMM = PlayFabMultiplayerManager.Get();
            pfMM.OnRemotePlayerJoined += PfMM_OnPlayerJoined;
            pfMM.OnRemotePlayerLeft += PfMM_OnPlayerLeft;
        }

        private void PfMM_OnPlayerLeft(object sender, PlayFabPlayer pfPlayer)
        {
            // Find the player in our list and remove it.
            Player playerToRemove = null;
            foreach (var player in players)
            {
                if (pfPlayer.EntityKey.Id == player.entityKey.Id)
                {
                    playerToRemove = player;
                    break;
                }
            }
            if (playerToRemove != null)
            {
                Destroy(playerToRemove.playerGO);
                players.Remove(playerToRemove);
            }
        }

        private void PfMM_OnPlayerJoined(object sender, PlayFabPlayer pfPlayer)
        {
            Player newPlayer = new Player();
            newPlayer.entityKey = pfPlayer.EntityKey;
            newPlayer.name = Random.value.ToString();

            //if (!pfPlayer.IsLocal)
            //{
            var playerGO = Instantiate(playerListItemPrefab);
            PlayerListItem playerItemBehavior = playerGO.GetComponent<PlayerListItem>();
            playerItemBehavior.entityIDEl.text = newPlayer.entityKey.Id;
            playerDetailsentityIDEl.text = newPlayer.entityKey.Id;
            playerItemBehavior.nameEl.text = newPlayer.name;
            playerItemBehavior.chatStateEl.text = pfPlayer.ChatState.ToString();
            playerItemBehavior.showDetailsButtonBehavior.languageCodeInput = languageCodeInputEl;
            playerItemBehavior.showDetailsButtonBehavior.voiceLevelInput = voiceLevelInputEl;
            playerItemBehavior.pfPlayer = pfPlayer;

            newPlayer.pfPlayer = pfPlayer;
            newPlayer.playerListItem = playerItemBehavior;
            newPlayer.playerGO = playerGO;

            players.Add(newPlayer);

            playerGO.transform.parent = gameObject.transform;
            playerGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, offset);

            offset -= 44f;
            //}
        }

        // Update is called once per frame
        void Update()
        {
            if (players == null)
            {
                return;
            }
            var pfMM = PlayFabMultiplayerManager.Get();
            foreach (var player in players)
            {
                PlayFabPlayer pfPlayer = player.pfPlayer;
                player.playerListItem.chatStateEl.text = pfPlayer.ChatState.ToString();
                player.playerListItem.muteButtonText.text = pfPlayer.IsMuted ? "Unmute" : "Mute";
            }
        }

        private bool CheckIfPlayerExists(PFEntityKey entityKey)
        {
            foreach (var player in players)
            {
                if (player.entityKey.Id == entityKey.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public Player GetPlayerByEntityId(PFEntityKey entityKey)
        {
            foreach (var player in players)
            {
                if (entityKey.Id == player.entityKey.Id)
                {
                    return player;
                }
            }
            return null;
        }
    }
}
