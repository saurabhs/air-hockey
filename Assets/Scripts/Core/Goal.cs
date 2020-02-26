using UnityEngine;
using UnityEngine.Events;

namespace AirHockey.Core
{
    public class OnGoalScored : UnityEvent<int> { }

    public class Goal : MonoBehaviour
    {
        [SerializeField] private int _id;

        public OnGoalScored onGoalScored = new OnGoalScored();

        private void OnCollisionEnter2D(Collision2D other)
        {
            onGoalScored.Invoke(_id);

            var puck = other.gameObject;
            puck.transform.position = Vector2.zero;
            puck.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}