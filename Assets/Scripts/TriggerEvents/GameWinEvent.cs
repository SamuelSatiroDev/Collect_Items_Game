using UnityEngine;
using UnityEngine.Events;

namespace TriggerEvents
{
    public sealed class GameWinEvent : MonoBehaviour
    {
        public UnityEvent OnGameWin = new UnityEvent();

        private void Start()
        {
            GameManagerData.Instance.OnGameWin += IvokeEvent;
        }

        private void OnDisable()
        {
            GameManagerData.Instance.OnGameWin -= IvokeEvent;
        }

        private void IvokeEvent()
        {
            OnGameWin?.Invoke();
        }
    }
}