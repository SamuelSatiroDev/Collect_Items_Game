using UnityEngine;
using UnityEngine.UI;

namespace LoadSceneSystem
{
    [RequireComponent(typeof(LoadScene))]
    public sealed class UILoadScene : MonoBehaviour
    {
        [SerializeField] private Button _loadCurrentScene = null;
        private LoadScene _loadScene = null;

        private void Awake()
        {
            _loadScene = GetComponent<LoadScene>();

            _loadCurrentScene?.onClick.AddListener(_loadScene.HandlerLoadCurrentScene);
        }
    }
}