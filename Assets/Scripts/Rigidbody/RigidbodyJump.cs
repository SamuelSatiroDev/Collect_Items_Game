using UnityEngine;

namespace RigidbodyMovementSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class RigidbodyJump : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 0.0f;
        [SerializeField] private float _groundDistance = 0.0f;

        private Rigidbody _rigidbody = null;

        public event System.Action OnJump;
        public event System.Action OnJumping;

        public bool IsGrounded
        {
            get
            {
                RaycastHit _raycastHit;
                bool isGrounded = false;
                if (Physics.Raycast(transform.position, Vector3.down, out _raycastHit, _groundDistance))
                {
                    if (_raycastHit.transform.tag == GameManagerData.TAG_CAN_JUMP)
                    {
                        
                        isGrounded = true;
                    }
                }

                return isGrounded;
            } 
        }

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        private void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position, Vector3.down * _groundDistance);
        }

        private void FixedUpdate()
        {
            if (IsGrounded == false)
            {
                OnJumping?.Invoke();
            }
        }

        public void HandlerJump()
        {
            if (IsGrounded == false)
            {
                return;
            }

            OnJump?.Invoke();
            _rigidbody.velocity = Vector3.up * _jumpForce;
        }
    }
}