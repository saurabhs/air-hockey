using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

namespace AirHockey.Network
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
        public TextMeshProUGUI debug = null;

        private void Start()
        {
            if (!PhotonNetwork.IsConnected)
                PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnEnable() => PhotonNetwork.AddCallbackTarget(this);

        public override void OnDisable() => PhotonNetwork.RemoveCallbackTarget(this);

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.JoinLobby(TypedLobby.Default);
        }

        public override void OnJoinedLobby()
        {
            PhotonNetwork.JoinOrCreateRoom($"AirHockeyRoom", new RoomOptions() { IsVisible = false, MaxPlayers = 2 }, TypedLobby.Default);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LocalPlayer.NickName = $"Player_{Random.Range(0, 10000)}";
            PhotonNetwork.LoadLevel("Main");
        }

    }
}