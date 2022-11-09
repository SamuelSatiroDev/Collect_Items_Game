using UnityEngine;
using TriggerEvents;

namespace CollectibleSystem
{
    [RequireComponent(typeof(TriggerEvent))]
    public sealed class Collectible : MonoBehaviour
    {
        private TriggerEvent _triggerEvent = null;

        private void Awake()
        {
            _triggerEvent = GetComponent<TriggerEvent>();
            _triggerEvent.SetColliderTag = GameManagerData.TAG_PLAYER;
        }

        private void Start()
        {
            _triggerEvent.OnTriggerEnterEvent.AddListener(DisableCollectible);
            _triggerEvent.OnTriggerEnterEvent.AddListener(GameManagerData.Instance.SoundManager.HandlerPlaySFXTakeCollectible);
        }

        private void DisableCollectible()
        {
            GameManagerData.Instance.CollectibleManager.Collectibles[gameObject.name].HandlerSetCollectibleCount(1);
            gameObject.SetActive(false);
        }
    }
}