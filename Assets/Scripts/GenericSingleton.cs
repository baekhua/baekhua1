using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static GenericSingleton<T> instance;
    public static GenericSingleton<T> Instance { get { return instance; } }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
