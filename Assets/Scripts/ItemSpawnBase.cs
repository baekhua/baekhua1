using UnityEngine;

public class ItemSpawnBase : MonoBehaviour
{
    [SerializeField] Transform[] _itemPoints;
    private void Start()
    {
        GenericSingleton<ItemSpawner>.Instance.GetComponent<ItemSpawner>().SpawnerInit(_itemPoints);
    }
}
