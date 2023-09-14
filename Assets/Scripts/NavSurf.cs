using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.Pool;

public class NavSurf : MonoBehaviour
{
    Transform _target;
    NavMeshSurface _surf;

    IObjectPool<NavSurf> _surfPool;

    private void Awake()
    {
        _surf = GetComponent<NavMeshSurface>();
    }
    public void SetPool(IObjectPool<NavSurf> pool) => _surfPool = pool;
    public void SetTarget(Transform target) => _target = target;
    float timer = 0;
    private void Update()
    {
        if (_target == null || _target.gameObject.activeSelf == false) Release();
        if(timer > 0.5f)
        {
            transform.position = _target.position;
            _surf.BuildNavMesh();
            timer = 0;
        }
    }
    public void Release()
    {
        timer = 0;
        _surfPool.Release(this);
    }
}
