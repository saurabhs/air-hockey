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

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby(TypedLobby.Default);
        }

        public override void OnJoinedLobby()
        {
            PhotonNetwork.JoinOrCreateRoom($"AirHockeyRoom", new RoomOptions() { IsVisible = false, MaxPlayers = 2 }, TypedLobby.Default);
        }

        public override void OnJoinedRoom()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        }
    }
}