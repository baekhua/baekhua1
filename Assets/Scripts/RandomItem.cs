using UnityEngine;

public class RandomItem : MonoBehaviour
{
    [SerializeField] GameObject[] _itemPrefabs;
    [SerializeField] int _items;
    [SerializeField] float _spawnRadius;
    private void Start()
    {
        PlaceRandomItems();
    }
    void PlaceRandomItems()
    {
        for(int i = 0; i < _items; i++)
        {
            Vector3 RandomPosition = Random.insideUnitSphere * _spawnRadius;
            RandomPosition.y = 0f;

            Instantiate(_itemPrefabs[Random.Range(0, _itemPrefabs.Length)], RandomPosition, Quaternion.identity);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _spawnRadius);
    }
}
