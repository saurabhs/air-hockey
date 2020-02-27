using UnityEngine;

namespace AirHockey.Core
{
    public class ForceHandler : MonoBehaviour
    {
        private Move _move = null;

        [SerializeField] private float _multiplier = 200f;

        private void Awake() => _move = GetComponent<Move>();
        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                var input = other.gameObject.GetComponent<InputHandler>();
                _move.Execute(input.Displacement * _multiplier);
            }
        }
    }
}