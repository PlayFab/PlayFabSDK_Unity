using PartyCSharpSDK;
using PlayFab.Party;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace PartyTestApp
{
    public class PlayerDetails : MonoBehaviour
    {
        public Text entityID;
        public InputField languageCode;
        public InputField voiceLevel;
        public Toggle useChatTranslation;
        public Toggle useSpeechToText;
        public Toggle useTextToSpeech;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateValues()
        {
            var pfMM = PlayFabMultiplayerManager.Get();
            pfMM.LocalPlayer.LanguageCode = languageCode.text;

            // update local user's chat control values only when it is already created
            if (pfMM.LocalPlayer.IsChatControlAvailable)
            {
                // incoming chat translation to local user's language
                pfMM.TranslateChat = useChatTranslation.isOn;

                // conversion of incoming speech of remote users or outgoing speech of the local user to text for the local user
                if (useSpeechToText.isOn)
                {
                    pfMM.SpeechToTextMode = AccessibilityMode.Enabled;
                }
                else
                {
                    pfMM.SpeechToTextMode = AccessibilityMode.None;
                }

                // conversion of outgoing text of the local user to synthesized speech sent to remote users
                if (useTextToSpeech.isOn)
                {
                    pfMM.TextToSpeechMode = AccessibilityMode.Enabled;
                }
                else
                {
                    pfMM.TextToSpeechMode = AccessibilityMode.None;
                }

            }

            if (IsRemoteUserSelected())
            {
                var pfPlayer = GetPlayerByEntityID(entityID.text);
                if (!string.IsNullOrWhiteSpace(voiceLevel.text))
                {
                    pfPlayer.VoiceLevel = float.Parse(voiceLevel.text, CultureInfo.InvariantCulture.NumberFormat);
                }
            }
        }

        private PlayFabPlayer GetPlayerByEntityID(string entityID)
        {
            var pfMM = PlayFabMultiplayerManager.Get();
            foreach (var player in pfMM.RemotePlayers)
            {
                if (player.EntityKey.Id == entityID)
                {
                    return player;
                }
            }
            return null;
        }

        private bool IsRemoteUserSelected()
        {
            return !string.IsNullOrWhiteSpace(entityID.text);
        }
    }
}