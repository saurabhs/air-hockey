using Photon.Pun;
using UnityEngine;

namespace AirHockey.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Move : MonoBehaviour, IPunObservable
    {
        //private Rigidbody2D _rb = null;

        private bool _canMove = false;

        private Vector2 _force = Vector2.zero;

        private float _speed = 0f;

        private Vector3 _target = Vector3.zero;

        public void Execute(Vector2 force)
        {
            _force = force;
            _speed = _force.magnitude;
            _canMove = true;

            _target = transform.position + new Vector3(_force.x, _force.y, 0);
        }

        private void Update()
        {
            if(_canMove)
            {
                transform.position = Vector2.Lerp(transform.position, _target, _speed * Time.deltaTime);

                if(Vector3.Distance(transform.position, _target) < 0.01f)
                    _canMove = false;
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
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