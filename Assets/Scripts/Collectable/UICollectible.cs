using UnityEngine;

namespace CollectibleSystem
{
    public sealed class UICollectible : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Image _icon = null;
        [SerializeField] private TMPro.TMP_Text _count = null;
        private string _collectibleName = string.Empty;

        private void Start()
        {
            GameManagerData.Instance.CollectibleManager.Collectibles[_collectibleName].OnCheckCollectiblesCount += HandlerUpdateCount;
        }

        private void OnDisable()
        {
            GameManagerData.Instance.CollectibleManager.Collectibles[_collectibleName].OnCheckCollectiblesCount -= HandlerUpdateCount;
        }

        public void HandlerUpdateInfo(Sprite icon,string collectibleName)
        {
            _icon.sprite = icon;
            _collectibleName = collectibleName;
            GameManagerData.Instance.CollectibleManager.Collectibles[_collectibleName].HandlerCheckCollectibleCount();
        }

        public void HandlerUpdateCount(byte count, byte max) => _count.text = $"{count.ToString("00")}/ {max.ToString("00")}";
    }
}