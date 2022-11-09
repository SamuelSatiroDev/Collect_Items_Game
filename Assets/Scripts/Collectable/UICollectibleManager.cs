using UnityEngine;

namespace CollectibleSystem
{
    public sealed class UICollectibleManager : MonoBehaviour
    {
        [SerializeField] private UICollectible _collectiblePrefabUI = null;
        [SerializeField] private RectTransform _collectibleUIContent = null;

        private void Start() => CollectibleInstatiateUI();

        private void CollectibleInstatiateUI()
        {
            foreach (var collectible in GameManagerData.Instance.CollectibleManager._collectibles)
            {
                UICollectible newUICollectible = Instantiate(_collectiblePrefabUI.gameObject, _collectibleUIContent).GetComponent<UICollectible>();
                collectible.OnCheckCollectiblesCount += newUICollectible.HandlerUpdateCount;
                newUICollectible.HandlerUpdateInfo(collectible.collectibleIcon, collectible.collectibleName);
            }
        }
    }
}