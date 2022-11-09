using UnityEngine;
using RigidbodyMovementSystem;

[RequireComponent(typeof(RigidbodyVelocityDirectionRotate))]
[RequireComponent(typeof(RigidbodyJump))]
[RequireComponent(typeof(RigidbodyMove))]
public sealed class PlayerControl : MonoBehaviour
{
    private RigidbodyMove _rigidbodyMove = null;
    private RigidbodyJump _rigidbodyJump = null;
    private RigidbodyVelocityDirectionRotate _rigidbodyVelocityDirection = null;

    private Vector3 AxisMovement => new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

    private void Awake()
    {
        _rigidbodyMove = GetComponent<RigidbodyMove>();
        _rigidbodyJump = GetComponent<RigidbodyJump>();
        _rigidbodyVelocityDirection = GetComponent<RigidbodyVelocityDirectionRotate>();
    }

    private void OnEnable()
    {
        GameManagerData.Instance.OnGameWin += DisableComponentsMove;
        GameManagerData.Instance.OnGameOver += DisableComponentsMove;
    }

    private void OnDisable()
    {
        GameManagerData.Instance.OnGameWin -= DisableComponentsMove;
        GameManagerData.Instance.OnGameOver -= DisableComponentsMove;
    }

    private void Update()
    {
        _rigidbodyMove.HandlerSetMovement(AxisMovement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbodyJump.HandlerJump();
        }
    }

    private void DisableComponentsMove()
    {
        _rigidbodyMove.enabled = false;
        _rigidbodyJump.enabled = false;
        _rigidbodyVelocityDirection.enabled = false;
        enabled = false;
    }
}