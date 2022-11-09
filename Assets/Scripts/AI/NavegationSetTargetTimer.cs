using UnityEngine;
using TriggerEvents;

[RequireComponent(typeof(NavegationMove))]
[RequireComponent(typeof(IEnumeratorEvent))]
[RequireComponent(typeof(TransformGroup))]
public sealed class NavegationSetTargetTimer : MonoBehaviour
{
    private NavegationMove _navegationMove;
    private IEnumeratorEvent _iEnumeratorEvent;
    private TransformGroup _transformGroup;

    private void Awake()
    {
        _navegationMove = GetComponent<NavegationMove>();
        _iEnumeratorEvent = GetComponent<IEnumeratorEvent>();
        _transformGroup = GetComponent<TransformGroup>();
    }

    private void OnEnable()
    {
        _navegationMove.OnStop += _iEnumeratorEvent.HandlerInvokeIEnumerator;
        _iEnumeratorEvent.OnEndTimer += HandlerSelectRandomTarget;
    }

    private void OnDisable()
    {
        _navegationMove.OnStop -= _iEnumeratorEvent.HandlerInvokeIEnumerator;
        _iEnumeratorEvent.OnEndTimer -= HandlerSelectRandomTarget;
    }

    public void HandlerSelectRandomTarget()
    {
        int randomTranform = Random.Range(0, _transformGroup.Transforms.Length);

        Vector3 newDestination = _transformGroup.Transforms[randomTranform].position;
        _navegationMove.HandlerSetDestination(newDestination);

        _navegationMove.enabled = true;
    }
}