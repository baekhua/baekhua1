using UnityEngine;

public class BranchSpawn : MonoBehaviour
{
    [SerializeField] GameObject _branchPrefab;
    [SerializeField] Transform _spawnPosition;
    float _spawnTime = 60f;
    float _timer;
    private void Start()
    {
        SpawnBranch();
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= _spawnTime)
        {
            SpawnBranch();
            _timer = 0;
        }
    }
    void SpawnBranch()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
        _spawnPosition.position = spawnPosition;
        GameObject branch = Instantiate(_branchPrefab, _spawnPosition.position, Quaternion.identity);
    }
}
