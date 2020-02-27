using Photon.Pun;
using TMPro;
using UnityEngine;

namespace AirHockey.Core
{
    public class Cosmetics : MonoBehaviour
    {
        public TextMeshProUGUI debug = null;

        private void Awake()
        {
            debug = GameObject.FindWithTag("Debug").GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            var view = GetComponent<PhotonView>();
            debug.text += $"Cosmetics : Actor No. : {view.Owner.ActorNumber}\n";
            GetComponent<SpriteRenderer>().color = Constants.GetColor(view.Owner.ActorNumber - 1);
        }
    }
}