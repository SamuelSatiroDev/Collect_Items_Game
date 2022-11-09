using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public sealed class NavegationMove : MonoBehaviour
{
    [SerializeField] private float _stoppingDistance = 2f;
    [SerializeField] private GameObject _fielOfVision = null;
    private Vector3 _currentPosition = Vector3.zero;
    private NavMeshAgent _navMeshAgent = null;

    public event System.Action OnStop;
    public event System.Action OnMoving;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.stoppingDistance = _stoppingDistance;
        HandlerSetDestination(transform.position);
    }

    private void Start()
    {
        GameManagerData.Instance.AIFieldOfVisionManager.fielOfVision.Add(_fielOfVision);
    }

    private void Update()
    {
        if (_navMeshAgent.remainingDistance <= _stoppingDistance)
        {
            OnStop?.Invoke();
            enabled = false;
        }
        else
        {
            OnMoving?.Invoke();
        }
    }

    public void HandlerSetDestination(Vector3 NewDestination)
    {
        if(Application.isPlaying == false)
        {
            return;
        }

        _currentPosition = NewDestination;
        _navMeshAgent.destination = _currentPosition;
    }
}