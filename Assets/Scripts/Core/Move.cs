using Photon.Pun;
using UnityEngine;

namespace AirHockey.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Move : MonoBehaviour, IPunObservable
    {
        private Rigidbody2D _rb = null;
        private void Awake() => _rb = GetComponent<Rigidbody2D>();

        public void Execute(Vector2 force) => _rb.AddForce(force, ForceMode2D.Force);

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            print("OnPhotonSerializeView");

            if (stream.IsWriting)
            {
                stream.SendNext(transform.position);
            }
            else
            {
                transform.position = (Vector3)stream.ReceiveNext();
            }
        }

#if UNITY_EDITOR
        [NaughtyAttributes.Button]
        public void MoveTest() => Execute(new Vector2(150, 150));
#endif
    }
}