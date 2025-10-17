using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using PlayFab.Party;

namespace PartyTestApp
{
    public class DataMessage : MonoBehaviour
    {
        public Text dataMessages;
        public InputField dataMessageValue;

        private List<PlayFabPlayer> _remotePlayers;

        // Start is called before the first frame update
        void Start()
        {
            var pfMM = PlayFabMultiplayerManager.Get();
            pfMM.OnDataMessageReceived += LocalPlayer_OnDataMessageReceived;
        }

        private void LocalPlayer_OnDataMessageReceived(object sender, PlayFabPlayer from, byte[] buffer)
        {
            // Add the message to the text element
            dataMessages.text += "\n" + Encoding.Default.GetString(buffer);
        }

        public void SendDataMessage()
        {
            var pfMM = PlayFabMultiplayerManager.Get();
            byte[] buffer = Encoding.ASCII.GetBytes(dataMessageValue.text);

            // Complicated version
            _remotePlayers = new List<PlayFabPlayer>();
            foreach (var player in pfMM.RemotePlayers)
            {
                _remotePlayers.Add(player);
            }

            IntPtr unmanagedPointer = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, unmanagedPointer, buffer.Length);
            pfMM.SendDataMessage(unmanagedPointer, (uint)buffer.Length, _remotePlayers, DeliveryOption.BestEffort);
            Marshal.FreeHGlobal(unmanagedPointer);
        }

        public void SendDataMessageToAllPlayers()
        {
            var pfMM = PlayFabMultiplayerManager.Get();
            byte[] buffer = Encoding.ASCII.GetBytes(dataMessageValue.text);
            pfMM.SendDataMessageToAllPlayers(buffer);
        }
    }
}
