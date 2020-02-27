using Photon.Pun;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AirHockey.Core
{
    public class InputHandler : MonoBehaviour, /*IBeginDragHandler,*/ IDragHandler, /*IEndDragHandler,*/ IPunObservable
    {
        private Vector3 _displacement = Vector2.zero;
        [SerializeField] private float _dragMultiplier = 500f;

        public Vector3 Displacement => _displacement;

        private PhotonView _view = null;

        private void Awake() => _view = GetComponent<PhotonView>();

        public void OnDrag(PointerEventData eventData)
        {
            if(_view.IsMine)
            {
                _displacement = new Vector3(eventData.delta.x, eventData.delta.y, 0);
                transform.position += _displacement / _dragMultiplier;
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                var position = transform.position;
                stream.Serialize(ref position);
            }
            else
            {
                var position = Vector3.zero;
                stream.Serialize(ref position);
                if (position != Vector3.zero)
                    transform.position = position;
            }
        }
    }
}