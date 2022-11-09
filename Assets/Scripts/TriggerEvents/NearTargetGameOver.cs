using UnityEngine;

[RequireComponent(typeof(NavegationFollowTarget))]
public sealed class NearTargetGameOver : MonoBehaviour
{
    private NavegationFollowTarget _navegationFollowTarget = null;

    private void Awake() => _navegationFollowTarget = GetComponent<NavegationFollowTarget>();

    private void OnEnable()
    {
        _navegationFollowTarget.OnNearTarget += GameManagerData.Instance.HandlerGameOver;
    }

    private void OnDisable()
    {
        _navegationFollowTarget.OnNearTarget -= GameManagerData.Instance.HandlerGameOver;
    }
}