using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NavegationSoundControl : MonoBehaviour
{
    [SerializeField] private NavegationMove _navegationMove = null;
    [SerializeField] private NavegationFollowTarget _navegationFollowTarget = null;

    [Space]

    [SerializeField] private float _speedPlayRun = 0.2f;
    [SerializeField] private AudioClip _sfxIdle = null;
    [SerializeField] private AudioClip _sfxRun = null; 
    [SerializeField] private AudioClip _sfxAttack = null;

    private AudioSource _audioSource = null;
    private float _speedPlayRunCount = 0;
    private bool _attack = false;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    private void OnEnable()
    {
        _navegationMove.OnStop += HandlerPlaySFXIdle;
        _navegationMove.OnMoving += HandlerPlaySFXRun;
        _navegationFollowTarget.OnNearTarget += HandlerPlaySFXAttack;
    }

    private void OnDisable()
    {
        _navegationMove.OnStop -= HandlerPlaySFXIdle;
        _navegationMove.OnMoving -= HandlerPlaySFXRun;
        _navegationFollowTarget.OnNearTarget -= HandlerPlaySFXAttack;
    }

    private void HandlerPlaySFXIdle()
    {
        if (_sfxIdle != null)
        {
            _audioSource.PlayOneShot(_sfxIdle);
        }
    }

    private void HandlerPlaySFXRun()
    {
        if(_speedPlayRunCount < _speedPlayRun)
        {
            _speedPlayRunCount += Time.deltaTime;
        }
        else
        {
            if (_sfxRun != null)
            {
                _audioSource.PlayOneShot(_sfxRun);
            }

            _speedPlayRunCount = 0;
        }
    }

    private void HandlerPlaySFXAttack()
    {
        if(_attack == true)
        {
            return;
        }

        _attack = true;

        if (_sfxAttack != null)
        {
            _audioSource.PlayOneShot(_sfxAttack);
        }
    }
}