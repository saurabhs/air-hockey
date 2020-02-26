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

    public class ScoreManager : MonoBehaviour
    {
        public class OnScoreUpdated : UnityEvent<(int, int)> { }

        [SerializeField] private ScoreData[] scoreData;

        public OnScoreUpdated onScoreUpdated = new OnScoreUpdated();
        private void Start()
        {
            scoreData[0].goal.onGoalScored.AddListener(OnGoalScored);
            scoreData[1].goal.onGoalScored.AddListener(OnGoalScored);
        }
        private void OnGoalScored(int id)
        {
            scoreData[id].score++;
            onScoreUpdated.Invoke((scoreData[0].score, scoreData[1].score));
        }
    }
}