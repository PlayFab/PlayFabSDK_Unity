using PartyCSharpSDK;
using PlayFab.Party;
using UnityEngine;
using UnityEngine.UI;

namespace PartyTestApp
{
    public class EventsOutput : MonoBehaviour
    {
        public Text eventsOutput;
        public Text connTypeOutput;

        // Start is called before the first frame update
        void Start()
        {
            var pfMM = PlayFabMultiplayerManager.Get();
            pfMM.OnError += PfMM_OnError;
            pfMM.OnNetworkChanged += PfMM_OnNetworkChanged;
            pfMM.OnNetworkJoined += PfMM_OnNetworkJoined;
            pfMM.OnNetworkLeft += PfMM_OnNetworkLeft;
            pfMM.OnRemotePlayerJoined += PfMM_OnPlayerJoined;
            pfMM.OnRemotePlayerLeft += PfMM_OnPlayerLeft;
        }

        private void PfMM_OnPlayerLeft(object sender, PlayFabPlayer player)
        {
            eventsOutput.text = "Player Left. ID:" + player.EntityKey.Id;
        }

        private void PfMM_OnPlayerJoined(object sender, PlayFabPlayer player)
        {
            var pfMM = PlayFabMultiplayerManager.Get();
            eventsOutput.text ="Player Joined. ID:" + player.EntityKey.Id;
            PARTY_DEVICE_CONNECTION_TYPE connType;
            GetConnectionType(pfMM, out connType);
            switch (connType)
            {
                case PartyCSharpSDK.PARTY_DEVICE_CONNECTION_TYPE.PARTY_DEVICE_CONNECTION_TYPE_RELAY_SERVER:
                    connTypeOutput.text = "RELAY";
                    break;
                case PartyCSharpSDK.PARTY_DEVICE_CONNECTION_TYPE.PARTY_DEVICE_CONNECTION_TYPE_DIRECT_PEER_CONNECTION:
                    connTypeOutput.text = "P2P";
                    break;
            }
        }

        private void PfMM_OnNetworkLeft(object sender, string networkID)
        {
            eventsOutput.text = "Network Left. Network ID:" + networkID;
        }

        private void PfMM_OnNetworkJoined(object sender, string networkID)
        {
            eventsOutput.text = "Network Joined. Network ID:" + networkID;
        }

        private void PfMM_OnNetworkChanged(object sender, string newNetworkID)
        {
            eventsOutput.text = "Network changed. Network ID: " + newNetworkID;
        }

        private void PfMM_OnError(object sender, PlayFabMultiplayerManagerErrorArgs args)
        {
            eventsOutput.text = "Error Code: " + args.Code + " , Message: " + args.Message;
        }

        private void GetConnectionType(PlayFabMultiplayerManager pfMM, out PARTY_DEVICE_CONNECTION_TYPE connType)
        {
            PARTY_DEVICE_HANDLE[] devices;
            SDK.PartyNetworkGetDevices(pfMM.PartyNetworkHandle, out devices);
            for (uint idx = 0; idx < devices.Length; idx++)
            {
                bool isLocal;
                SDK.PartyDeviceIsLocal(devices[idx], out isLocal);
                if (!isLocal)
                {
                    SDK.PartyNetworkGetDeviceConnectionType(pfMM.PartyNetworkHandle,
                                                            devices[idx],
                                                            out connType);
                    return;
                }
            }
            connType = PARTY_DEVICE_CONNECTION_TYPE.PARTY_DEVICE_CONNECTION_TYPE_RELAY_SERVER;
        }
    }
}
