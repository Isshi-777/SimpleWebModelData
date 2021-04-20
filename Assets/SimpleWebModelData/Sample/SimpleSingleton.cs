using UnityEngine;

public abstract class SimpleSingleton<T> where T : class, new()
{
    private static T instance = new T();

    protected SimpleSingleton()
    {
        Debug.Assert(null == instance);
    }

    public static T GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError(" instance is null ! type -> " + typeof(T).ToString());
            return null;
        }

        return instance;
    }
}
