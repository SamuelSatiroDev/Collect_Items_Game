using UnityEngine;
using TriggerEvents;

[RequireComponent(typeof(NavegationMove))]
[RequireComponent(typeof(IEnumeratorEvent))]
public sealed class NavegationFollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target = null;

    private NavegationMove _navegationMove = null;
    private IEnumeratorEvent _enumeratorEvent = null;

    public event System.Action OnNearTarget;
    public event System.Action OnFarTarget;

    private void Awake()
    {
        _navegationMove = GetComponent<NavegationMove>();
        _enumeratorEvent = GetComponent<IEnumeratorEvent>();     
    }

    private void OnEnable()
    {
        _navegationMove.HandlerSetDestination(_target.position);
        _navegationMove.enabled = true;

        GameManagerData.Instance.OnGameWin += GameWinEvent;

        _navegationMove.OnMoving += HandlerFarTarget;
        _navegationMove.OnStop += HandlerNearTarget;

        _enumeratorEvent.StopAllCoroutines();
    }

    private void OnDisable()
    {
        GameManagerData.Instance.OnGameWin -= GameWinEvent;

        _navegationMove.OnMoving -= HandlerFarTarget;
        _navegationMove.OnStop -= HandlerNearTarget;
    }

    private void Start()
    {
        GameManagerData.Instance.AIFieldOfVisionManager.navegationFollowTarget.Add(this);
    }

    private void Update()
    {
        LookToTarget();
        _navegationMove.HandlerSetDestination(_target.position);
    }

    private void LookToTarget()
    {
        Vector3 targetPostition = new Vector3(_target.position.x, this.transform.position.y, _target.position.z);
        this.transform.LookAt(targetPostition);
    }

    private void HandlerNearTarget()
    {
        _enumeratorEvent.StopAllCoroutines();
        OnNearTarget?.Invoke();
    }

    private void HandlerFarTarget() => OnFarTarget?.Invoke();

    private void GameWinEvent()
    {
        _enumeratorEvent.StopAllCoroutines();
        enabled = false;
    }
}