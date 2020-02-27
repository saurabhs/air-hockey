using Photon.Pun;
using TMPro;
using UnityEngine;

namespace AirHockey.Core
{
    public class Cosmetics : MonoBehaviour
    {
        private void Awake()
        {
            var debug = GameObject.FindWithTag("Debug").GetComponent<TextMeshProUGUI>();

            var view = GetComponent<PhotonView>();
            if(view != null && view.Owner != null)
            {
                debug.text += $"Cosmetics : Actor No. : {view.Owner.ActorNumber}\n";
                GetComponent<SpriteRenderer>().color = Constants.GetColor(view.Owner.ActorNumber - 1);
            }
        }
    }
}