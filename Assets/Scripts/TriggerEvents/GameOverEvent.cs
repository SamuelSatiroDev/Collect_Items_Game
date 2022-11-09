using UnityEngine;
using UnityEngine.Events;

namespace TriggerEvents
{
    public sealed class GameOverEvent : MonoBehaviour
    {
        public UnityEvent OnGameOver = new UnityEvent();

        private void OnEnable()
        {
            GameManagerData.Instance.OnGameOver += IvokeEvent;
        }

        private void OnDisable()
        {
            GameManagerData.Instance.OnGameOver -= IvokeEvent;
        }

        private void IvokeEvent() => OnGameOver?.Invoke();
    }
}