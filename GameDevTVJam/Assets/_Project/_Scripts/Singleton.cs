using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic singleton and persistent singleton implementation with generic type.
/// </summary>

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }
    protected virtual void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this as T;
    }
    protected virtual void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }
}

public abstract class SingletonPersistent<T> : Singleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        base.Awake();
    }
}

