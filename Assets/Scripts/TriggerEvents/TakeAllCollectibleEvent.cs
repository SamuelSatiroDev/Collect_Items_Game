using UnityEngine;
using UnityEngine.Events;

namespace TriggerEvents
{
    public sealed class TakeAllCollectibleEvent : MonoBehaviour
    {
        public UnityEvent OnTakeAllCollectible = new UnityEvent();

        private void Start()
        {
            GameManagerData.Instance.CollectibleManager.OnTakeAllCollectible += InvokeEvent;
        }

        private void OnDisable()
        {
            GameManagerData.Instance.CollectibleManager.OnTakeAllCollectible -= InvokeEvent;
        }

        private void InvokeEvent()
        {
            OnTakeAllCollectible.Invoke();
        }
    }
}