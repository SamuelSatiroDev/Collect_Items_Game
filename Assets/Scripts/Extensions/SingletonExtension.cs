using UnityEngine;

namespace ExtensionMethods
{
	public class SingletonDefinitor<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T instance;
		public static T Get()
		{
			if (!instance)
			{
				Set(FindObjectOfType<T>());
				//Debug.LogWarning($"[Singleton] called Get<{typeof(T)}>() before instance was set");
			}
			return instance;
		}

		public static bool Set(T instance, bool dontDestroyOnLoad = true)
		{
			// NOTE: method does not need to be called; BUT if called, FindObjectOfType() is avoided during lazy init
			if (SingletonDefinitor<T>.instance)
			{
				//Debug.LogWarning($"[Singleton] {instance.name} called Set<{typeof(T)}>() when singleton already exists");
				if (!ReferenceEquals(SingletonDefinitor<T>.instance, instance)) DestroyImmediate(instance.gameObject);
				return false;
			}
			else
			{
				SingletonDefinitor<T>.instance = instance;
				if (dontDestroyOnLoad) 
				{
					instance.transform.SetParent(null);
					DontDestroyOnLoad(instance.gameObject);
				}
				return true;
			}
		}

		public static void Release()
		{
			if (!instance) return;
			Destroy(instance.gameObject);
		}
	}

	public class Singleton<T> : MonoBehaviour
		where T : Component
	{
		private static T _instance;
		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					var objs = FindObjectsOfType(typeof(T)) as T[];
					if (objs.Length > 0)
						_instance = objs[0];
					if (objs.Length > 1)
					{
						Debug.LogError($"Multiple instances of the singleton {typeof(T).Name} found");
					}
					if (_instance == null)
					{
						GameObject obj = new GameObject();
						obj.hideFlags = HideFlags.HideAndDontSave;
						_instance = obj.AddComponent<T>();
					}
				}
				return _instance;
			}
		}
	}


	public class SingletonPersistent<T> : MonoBehaviour
		where T : Component
	{
		public static T Instance { get; private set; }

		public virtual void Awake()
		{
			if (Application.isPlaying == false) { return; }

			transform.SetParent(null);

			if (Instance == null)
			{
				Instance = this as T;
				DontDestroyOnLoad(this);
			}
			else
			{
				Destroy(this.gameObject);
			}
		}
	}

	public class SingletonPersistentStart<T> : MonoBehaviour
		where T : Component
	{
		public static T Instance { get; private set; }
		public virtual void Start()
		{
			if (Application.isPlaying == false) { return; }

			transform.SetParent(null);

			if (Instance == null)
			{
				Instance = this as T;
				DontDestroyOnLoad(this);
			}
			else
			{
				Destroy(this.gameObject);
			}
		}
	}

	public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
	{
		private static T instance;
		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					instance = Resources.Load<T>(typeof(T).Name.ToString());
					(instance as ScriptableSingleton<T>).OnInitialize();
				}
				return instance;
			}
		}

		protected virtual void OnInitialize() { }
	}
}