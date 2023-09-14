using UnityEngine;
using UnityEngine.Pool;

public class IObjectPool : MonoBehaviour
{
    [SerializeField] GameObject _navSurf;
    [SerializeField] int _maxSurfCount;

    IObjectPool<NavSurf> _surfPool;

    private void Awake()
    {
        _surfPool = new ObjectPool<NavSurf>(CreateNav, OnGetNav, OnReleaseNav, OnDestroyNav, maxSize: _maxSurfCount);
    }
    private void Update()
    {
        _surfPool.Get();
    }
    NavSurf CreateNav()
    {
        NavSurf surf = Instantiate(_navSurf).GetComponent<NavSurf>();
        surf.SetPool(_surfPool);
        return surf;
    }
    void OnGetNav(NavSurf surf)
    {
        surf.gameObject.SetActive(true);
    }
    void OnReleaseNav(NavSurf surf)
    {
        surf.gameObject.SetActive(false);
    }
    void OnDestroyNav(NavSurf surf)
    {
        Destroy(surf.gameObject);
    }
}
