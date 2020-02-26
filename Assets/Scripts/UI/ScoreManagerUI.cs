using UnityEngine;
using TMPro;
using AirHockey.Core;

namespace AirHockey.UI
{
    public class ScoreManagerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _score = null;

        private void Awake()
        {
            var scoreManager = GetComponent<ScoreManager>();
            scoreManager.onScoreUpdated.AddListener(OnScoreUpdated);
        }

        private void OnScoreUpdated((int p1, int p2) scores)
        {
            _score.text = $"{scores.p1} : {scores.p2}";
        }
    }
}