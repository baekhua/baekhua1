using UnityEngine;
using UnityEngine.AI;

public class WolfNav : MonoBehaviour
{
    NavMeshAgent _agent;
    [SerializeField] Transform[] _target;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    //private void Update()
    //{
    //    _agent.SetDestination(_target[Random.Range(0, _target.Length)].transform.position);
    //}
}
