using UnityEngine;

namespace RigidbodyMovementSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class RigidbodyVelocityDirectionRotate : MonoBehaviour
    {
        [SerializeField] private float _speedRotation = 0;

        private Rigidbody _rigidbody = null;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        private void FixedUpdate()
        {
            Vector3 _direction = new Vector3(_rigidbody.velocity.x, 0.0f, _rigidbody.velocity.z);
            _direction.Normalize();

            if (_direction == Vector3.zero)
            {
                return;
            }

            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(_direction), _speedRotation * Time.fixedDeltaTime);
        }
    }
}