using UnityEngine;

[RequireComponent(typeof(ChanceAnimationState))]
[RequireComponent(typeof(NavegationMove))]
[RequireComponent(typeof(NavegationFollowTarget))]
public sealed class AIAnimationState : MonoBehaviour
{
    private NavegationMove _navegationMove = null;
    private NavegationFollowTarget _navegationFollowTarget = null;
    private ChanceAnimationState _chanceAnimationState = null;

    private const string ANIM_IDLE = "Idle";
    private const string ANIM_RUN = "Run";
    private const string ANIM_ATTACK = "Attack";

    private void Awake()
    {
        _navegationFollowTarget = GetComponent<NavegationFollowTarget>();
        _chanceAnimationState = GetComponent<ChanceAnimationState>();
        _navegationMove = GetComponent<NavegationMove>();
    }

    private void OnEnable()
    {    
        _navegationMove.OnStop += PlayAnimIdle;
        _navegationMove.OnMoving += PlayAnimRun;
        _navegationFollowTarget.OnNearTarget += PlayAnimAttack;
    }

    private void OnDisable()
    {     
        _navegationMove.OnStop -= PlayAnimIdle;
        _navegationMove.OnMoving -= PlayAnimRun;
        _navegationFollowTarget.OnNearTarget -= PlayAnimAttack;
    }

    private void PlayAnimIdle() => _chanceAnimationState.HandlerChangeAnimationState(ANIM_IDLE);
    private void PlayAnimRun() => _chanceAnimationState.HandlerChangeAnimationState(ANIM_RUN);
    private void PlayAnimAttack() => _chanceAnimationState.HandlerChangeAnimationState(ANIM_ATTACK); 
}