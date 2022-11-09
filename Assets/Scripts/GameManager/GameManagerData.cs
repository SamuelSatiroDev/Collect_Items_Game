using UnityEngine;
using ExtensionMethods;
using CollectibleSystem;

[CreateAssetMenu(fileName = "GameManagerData", menuName = "Game Datas/Game Manager")]
public sealed class GameManagerData : ScriptableSingleton<GameManagerData>
{
    private CollectibleManager _collectibleManager = null;
    private AIFieldOfVisionManager _AIFieldOfVisionManager = null;
    private SoundManager _soundManager = null;

    public const string TAG_PLAYER = "Player";
    public const string TAG_CAN_JUMP = "CanJump";

    public CollectibleManager CollectibleManager { get => GameManagerData.Instance._collectibleManager; set => GameManagerData.Instance._collectibleManager = value; }
    public AIFieldOfVisionManager AIFieldOfVisionManager { get => GameManagerData.Instance._AIFieldOfVisionManager; set => GameManagerData.Instance._AIFieldOfVisionManager = value; }
    public SoundManager SoundManager { get => GameManagerData.Instance._soundManager; set => GameManagerData.Instance._soundManager = value; }

    public event System.Action OnGameOver;
    public event System.Action OnGameWin;

    public void HandlerGameWin() => OnGameWin?.Invoke();

    public void HandlerGameOver() => OnGameOver?.Invoke();

    public void HandlerEnableAIFielOfVision(bool set)
    {
        foreach (var fielOfVision in _AIFieldOfVisionManager.fielOfVision)
        {
            fielOfVision.SetActive(set);
        }
    }

    public void HandlerEnableNavegationFollowTarget(bool set)
    {
        foreach (var navegationFollowTarget in _AIFieldOfVisionManager.navegationFollowTarget)
        {
            navegationFollowTarget.enabled = set;
        }
    }
}