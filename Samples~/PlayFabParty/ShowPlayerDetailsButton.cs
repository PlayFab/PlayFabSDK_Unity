using PlayFab.Party;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerDetailsButton : MonoBehaviour
{
    public Text entityID;
    public InputField languageCodeInput;
    public InputField voiceLevelInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDetails()
    {
        var pfMM = PlayFabMultiplayerManager.Get();
        var pfPlayer = GetPlayerByEntityID(entityID.text);
        languageCodeInput.text = pfMM.LocalPlayer.LanguageCode;
        voiceLevelInput.text = pfPlayer.VoiceLevel.ToString();
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
}
