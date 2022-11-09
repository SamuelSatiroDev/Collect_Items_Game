using UnityEngine;
using UnityEngine.Events;

namespace TriggerEvents
{
    public sealed class TriggerEvent : MonoBehaviour
    {
        [SerializeField] private string _colliderTag = string.Empty;
        public UnityEvent OnTriggerEnterEvent = new UnityEvent();
        public UnityEvent OnTriggerStayEvent = new UnityEvent();
        public UnityEvent OnTriggerExitEvent = new UnityEvent();

        public string SetColliderTag { set => _colliderTag = value; }

        private void Awake()
        {
            foreach (var collider in GetComponents<Collider>())
            {
                collider.isTrigger = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != _colliderTag)
            {
                return;
            }

            OnTriggerEnterEvent?.Invoke();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.tag != _colliderTag)
            {
                return;
            }

            OnTriggerStayEvent?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag != _colliderTag)
            {
                return;
            }

            OnTriggerExitEvent?.Invoke();
        }
    }
}