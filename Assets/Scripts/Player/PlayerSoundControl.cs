using UnityEngine;
using RigidbodyMovementSystem;

[RequireComponent(typeof(AudioSource))]
public sealed class PlayerSoundControl : MonoBehaviour
{
    [SerializeField] private RigidbodyJump _rigidbodyJumpPlayer = null;
    [SerializeField] private RigidbodyMove _rigidbodyMovePlayer = null;
    [SerializeField] private Rigidbody _rigidbodyPlayer = null;

    [Space]

    [SerializeField] private AudioClip _sfxRun = null;
    [SerializeField] private AudioClip _sfxJump = null;
    [SerializeField] private AudioClip _sfxDead = null;

    private AudioSource _audioSource = null;
    private bool _gameOver = false;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    private void OnEnable()
    {
        _rigidbodyJumpPlayer.OnJump += HandlerPlaySFXJump;
        _rigidbodyMovePlayer.OnMoving +=  HandlerPlaySFXRun;     
        GameManagerData.Instance.OnGameOver += HandlerPlaySFXDead;
    }

    private void OnDisable()
    {
        _rigidbodyJumpPlayer.OnJump -= HandlerPlaySFXJump;
        _rigidbodyMovePlayer.OnMoving -= HandlerPlaySFXRun;     
        GameManagerData.Instance.OnGameOver -= HandlerPlaySFXDead;
    }

    private void HandlerPlaySFXRun(Vector3 velocity)
    {
        if(_rigidbodyJumpPlayer.IsGrounded == false || _sfxRun == null)
        {
            return;
        }

        if(_rigidbodyPlayer.velocity.magnitude > 2f && _audioSource.isPlaying == false)
        {
            _audioSource.clip = _sfxRun;
            _audioSource.Play();
        }
    }

    private void HandlerPlaySFXJump()
    {
        if (_gameOver == true || _sfxJump == null)
        {
            return;
        }

        _audioSource.PlayOneShot(_sfxJump);
    }

    private void HandlerPlaySFXDead()
    {
        if(_gameOver == true || _sfxDead == null)
        {
            return;
        }

        _gameOver = true;
        _audioSource.PlayOneShot(_sfxDead);
    }
}