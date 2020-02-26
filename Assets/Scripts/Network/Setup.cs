using Photon.Pun;
using UnityEngine;

namespace AirHockey.Core
{
    public class Setup : MonoBehaviour
    {
        [SerializeField] private Transform _p1Pivot = null;
        [SerializeField] private Transform _p2Pivot = null;

        [SerializeField] private Color _p1Color = Color.red;
        [SerializeField] private Color _p2Color = Color.blue;

        public void Awake()
        {
            if (!PhotonNetwork.IsConnected)
                return;

            if (PhotonNetwork.IsMasterClient)
            {
                var p1 = PhotonNetwork.Instantiate("Player", _p1Pivot.position, Quaternion.identity);
                p1.GetComponent<SpriteRenderer>().color = _p1Color;

                PhotonNetwork.Instantiate("Puck", Vector2.zero, Quaternion.identity);
            }
            else
            {
                var p2 = PhotonNetwork.Instantiate("Player", _p2Pivot.position, Quaternion.identity);
                p2.GetComponent<SpriteRenderer>().color = _p2Color;
            }
        }
    }
}