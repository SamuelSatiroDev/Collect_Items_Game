using UnityEngine;
using TriggerEvents;

[RequireComponent(typeof(TriggerEvent))]
public sealed class TriggerInvokeGameWin : MonoBehaviour
{
    private TriggerEvent _triggerEvent = null;

    private void Awake()
    {     
        _triggerEvent = GetComponent<TriggerEvent>();
        _triggerEvent.SetColliderTag = GameManagerData.TAG_PLAYER;
        _triggerEvent.OnTriggerEnterEvent.AddListener(GameManagerData.Instance.HandlerGameWin);
    }
}