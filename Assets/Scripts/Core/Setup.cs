using Photon.Pun;
using UnityEngine;

namespace AirHockey.Core
{
    public class Setup : MonoBehaviour
    {
        [SerializeField] private Transform _p1Pivot = null;
        [SerializeField] private Transform _p2Pivot = null;

        public void Awake()
        {
            if (!PhotonNetwork.IsConnected)
                return;

            if (PhotonNetwork.IsMasterClient)
            {
                var p1 = PhotonNetwork.Instantiate("Player", _p1Pivot.position, Quaternion.identity);
                p1.name = "Player_Master";

                var puck = PhotonNetwork.Instantiate("Puck", Vector2.zero, Quaternion.identity);
                puck.name = "Puck";
            }
            else
            {
                var p2 = PhotonNetwork.Instantiate("Player", _p2Pivot.position, Quaternion.identity);
                p2.name = "Player_Client";
            }
        }
    }
}