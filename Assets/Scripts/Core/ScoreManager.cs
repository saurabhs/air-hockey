using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Events;

namespace AirHockey.Core
{
    [System.Serializable]
    public struct ScoreData
    {
        public Goal goal;
        public int score;
    }

    public class ScoreManager : MonoBehaviour, IPunObservable
    {
        public class OnScoreUpdated : UnityEvent<(int, int)> { }

        [SerializeField] private ScoreData[] _scoreData;

        public OnScoreUpdated onScoreUpdated = new OnScoreUpdated();

        private PhotonView _view = null;

        private void Awake() => _view = GetComponent<PhotonView>();

        private void Start()
        {
            _scoreData[0].goal.onGoalScored.AddListener(OnGoalScored);
            _scoreData[1].goal.onGoalScored.AddListener(OnGoalScored);
        }

        private void OnGoalScored(int id)
        {
            _scoreData[id].score++;
            onScoreUpdated.Invoke((_scoreData[0].score, _scoreData[1].score));

            //_view.RPC("SendScore", RpcTarget.Others);
        }

        //[PunRPC]
        //private void SendScore()
        //{ 
        //}

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if(stream.IsWriting)
            {
                stream.SendNext((object)_scoreData);
            }
            else
            {
                _scoreData = (ScoreData[])stream.ReceiveNext();
            }
        }
    }
}