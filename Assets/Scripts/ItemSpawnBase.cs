using UnityEngine;

public class ItemSpawnBase : MonoBehaviour
{
    [SerializeField] Transform[] _itemPoints;
    private void Awake()
    {
        GenericSingleton<ItemSpawner>.Instance.GetComponent<ItemSpawner>().SpawnerInit(_itemPoints);
    }
}
