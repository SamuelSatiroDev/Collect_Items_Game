using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LoadSceneSystem
{
    public sealed class LoadScene : MonoBehaviour
    {
        [SerializeField] private string _sceneName = string.Empty;
        [SerializeField] private Button _loadScene = null;

        private void Awake()
        {
            _loadScene?.onClick.AddListener(HandlerLoadScene);
        }

        public void HandlerLoadScene() => SceneManager.LoadScene(_sceneName);

        public void HandlerLoadCurrentScene()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}