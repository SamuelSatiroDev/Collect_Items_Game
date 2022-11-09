using System.Collections;
using UnityEngine;

namespace TriggerEvents
{
    public sealed class IEnumeratorEvent : MonoBehaviour
    {
        [SerializeField] private float _duration = 4.0f;
        [SerializeField] private bool _autoInitialize = false;

        public System.Action OnStartTimer;
        public System.Action OnEndTimer;
        public System.Action OnStopIEnumerator;

        private void Start()
        {
            if (_autoInitialize == true)
            {
                HandlerInvokeIEnumerator();
            }
        }

        public void HandlerInvokeIEnumerator()
        {
            StopCoroutine(Timer());
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            OnStartTimer?.Invoke();
            yield return new WaitForSeconds(_duration);
            OnEndTimer?.Invoke();
        }
    }
}