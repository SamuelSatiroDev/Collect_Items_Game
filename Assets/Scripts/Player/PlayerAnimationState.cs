using UnityEngine;
using RigidbodyMovementSystem;

[RequireComponent(typeof(PlayerControl))]
[RequireComponent(typeof(ChanceAnimationState))]
public sealed class PlayerAnimationState : MonoBehaviour
{
    private RigidbodyMove _rigidbodyMove = null;
    private RigidbodyJump _rigidbodyJump = null;
    private ChanceAnimationState _chanceAnimationState = null;
    private bool _gameOver = false;

    private const string ANIM_IDLE = "Idle";
    private const string ANIM_RUN = "Run";
    private const string ANIM_JUMP = "Jump";
    private const string ANIM_DEAD = "Dead";
   
    private void Awake()
    {
        _rigidbodyMove = GetComponent<RigidbodyMove>();
        _rigidbodyJump = GetComponent<RigidbodyJump>();
        _chanceAnimationState = GetComponent<ChanceAnimationState>();
        GameManagerData.Instance.OnGameOver += HandlerSetAnimDead;
    }

    private void OnEnable()
    {
        _rigidbodyMove.OnStopping += HandlerSetAnimIdle;
        _rigidbodyMove.OnMoving += HandlerSetAnimRun;
        _rigidbodyJump.OnJump += HandlerSetAnimJump;
        GameManagerData.Instance.OnGameOver += HandlerSetAnimDead;
    }

    private void OnDisable()
    {
        _rigidbodyMove.OnStopping -= HandlerSetAnimIdle;
        _rigidbodyMove.OnMoving -= HandlerSetAnimRun;
        _rigidbodyJump.OnJump -= HandlerSetAnimJump;
    }

    private void HandlerSetAnimJump() => _chanceAnimationState.HandlerChangeAnimationState(ANIM_JUMP);

    private void HandlerSetAnimDead()
    {
        _gameOver = true;
        _chanceAnimationState.HandlerChangeAnimationState(ANIM_DEAD);
    }

    private void HandlerSetAnimIdle(Vector3 Velocity)
    {
        if(_gameOver == true)
        {
            return;
        }

        string idle = _rigidbodyJump.IsGrounded == true ? ANIM_IDLE : ANIM_JUMP;
        _chanceAnimationState.HandlerChangeAnimationState(idle);
    }

    private void HandlerSetAnimRun(Vector3 Velocity)
    {
        if (_rigidbodyJump.IsGrounded == false || _gameOver == true)
        {
            return;
        }

        _chanceAnimationState.HandlerChangeAnimationState(ANIM_RUN);
    }
}