using UnityEngine;

public class BranchSpawn : MonoBehaviour
{
    [SerializeField] GameObject _branchPrefab;
    [SerializeField] Transform _spawnPosition;
    float _spawnTime = 0;
    float _timer;
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
        GameObject branch = Instantiate(_branchPrefab, _spawnPosition.position, Quaternion.identity);
    }
}
