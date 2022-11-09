using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public sealed class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _sfxGameWin = null;
    [SerializeField] private AudioClip _sfxGameOver = null;   

    [Space]

    [SerializeField] private AudioClip[] _sfxTakeCollectible = new AudioClip[] { };
    private AudioSource _audioSource = null;
    private bool _gameOver = false;
    private bool _gameWin = false;

    private void Awake()
    {      
        GameManagerData.Instance.SoundManager = this;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GameManagerData.Instance.OnGameOver += HandlerPlaySFXGameOver;
        GameManagerData.Instance.OnGameWin += HandlerPlaySFXGameWin;
    }

    private void OnDisable()
    {
        GameManagerData.Instance.OnGameOver -= HandlerPlaySFXGameOver;
        GameManagerData.Instance.OnGameWin -= HandlerPlaySFXGameWin;
    }

    private void HandlerPlaySFXGameOver()
    {
        if (_gameOver == true)
        {
            return;
        }

        _gameOver = true;
        _audioSource.PlayOneShot(_sfxGameOver);
    }

    private void HandlerPlaySFXGameWin()
    {
        if (_gameWin == true)
        {
            return;
        }

        _gameWin = true;
        _audioSource.PlayOneShot(_sfxGameWin);
    }

    public void HandlerPlaySFXTakeCollectible()
    {
        int randomIndex = Random.Range(0, _sfxTakeCollectible.Length);
        _audioSource.PlayOneShot(_sfxTakeCollectible[randomIndex]);
    }
}