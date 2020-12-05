using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviourSingleton<T>
{
    private static T instance = null;

    public static T GetInstance()
    {
        if (instance == null)
        {
            System.Type type = typeof(T);
            instance = GameObject.FindObjectOfType(type) as T;

            if (instance == null)
            {
                Debug.LogError(" Instance is null and not find target type -> " + type);
                return null;
            }
        }

        return instance;
    }

    protected virtual void Awake()
    {
        if (this != instance)
        {
            if (instance == null)
            {
                GetInstance();
                OnInitialize();
            }
            else
            {
                Destroy(this);
                Debug.LogWarning(" Destroy instance MonoBehaviourSingleton -> " + typeof(T) + " and GameObject name is " + instance.gameObject.name);
            }
        }
        else
        {
            OnInitialize();
        }
    }

    protected virtual void OnInitialize()
    {
        Debug.Log(" MonoBehaviourSingleton initialize typename -> " + typeof(T));
    }
}