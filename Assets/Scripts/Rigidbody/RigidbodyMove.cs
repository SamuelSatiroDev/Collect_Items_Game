using UnityEngine;

namespace RigidbodyMovementSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class RigidbodyMove : MonoBehaviour
    {
        [SerializeField] private float _speedMove = 0f;

        private Vector3 _movement = Vector3.zero;
        private Rigidbody _rigidbody = null;

        public event System.Action<Vector3> OnMoving;
        public event System.Action<Vector3> OnStopping;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        public void HandlerSetMovement(Vector3 Movement) => _movement = Movement * _speedMove;

        private void FixedUpdate()
        {
            if(_movement == Vector3.zero)
            {
                OnStopping?.Invoke(_rigidbody.velocity);
                return;
            }

            _rigidbody.velocity = new Vector3(_movement.x, _rigidbody.velocity.y, _movement.z);
            OnMoving?.Invoke(_rigidbody.velocity);
        }
    }
}