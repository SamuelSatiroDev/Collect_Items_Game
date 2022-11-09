using System.Collections.Generic;
using UnityEngine;

namespace CollectibleSystem
{
    public sealed class CollectibleManager : MonoBehaviour
    {
        public Collectible[] _collectibles = new Collectible[] { };

        public Dictionary<string, Collectible> Collectibles = new Dictionary<string, Collectible>();

        public event System.Action OnTakeAllCollectible;
        public event System.Action OnTakeCollectible;

        private void Awake()
        {
            GameManagerData.Instance.CollectibleManager = this;

            Collectibles.Clear();
            foreach (var collectible in _collectibles)
            {
                collectible.HandlerSearchCollectiblesByName();
                collectible.OnTakeAllCollectible += HandlerCheckTakeAllCollectible;
                Collectibles.Add(collectible.collectibleName, collectible);
            }
        }

        private void HandlerCheckTakeAllCollectible()
        {
            OnTakeCollectible?.Invoke();

            bool check = true;

            foreach (var collectible in _collectibles)
            {
                if(collectible.TakeAllCollectible == false)
                {
                    check = false;
                    break;
                }
            }

            if(check == true)
            {
                OnTakeAllCollectible?.Invoke();
            }
        }

        [System.Serializable]
        public class Collectible
        {
            public string collectibleName = string.Empty;
            public Sprite collectibleIcon = null;

            private byte _count = 0;
            private List<GameObject> _collectibles = new List<GameObject>();

            public bool TakeAllCollectible => _count >= _collectibles.Count;

            public event System.Action<byte, byte> OnCheckCollectiblesCount;
            public event System.Action OnTakeAllCollectible;

            public void HandlerSetCollectibleCount(int Count)
            {
                _count += (byte)Count;
                HandlerCheckCollectibleCount();
            }

            public void HandlerCheckCollectibleCount()
            {
                OnCheckCollectiblesCount?.Invoke(_count, (byte)_collectibles.Count);

                if (TakeAllCollectible == true)
                {
                    OnTakeAllCollectible?.Invoke();
                }
            }

            public void HandlerSearchCollectiblesByName()
            {
                _collectibles = new List<GameObject>();
                foreach (var gameObject in FindObjectsOfType(typeof(GameObject)) as GameObject[])
                {
                    if (gameObject.name == collectibleName)
                    {
                        gameObject.AddComponent<CollectibleSystem.Collectible>();
                        _collectibles.Add(gameObject);
                    }
                }
            }
        }
    }
}