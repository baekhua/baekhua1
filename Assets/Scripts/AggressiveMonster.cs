using System.Collections.Generic;
using UnityEngine;

public class AggressiveMonster : MonoBehaviour
{
    [Range(0f, 360f)][SerializeField] float _viewAngle = 0f;
    [SerializeField] float _viewRadius;
    [SerializeField] LayerMask _targetMask;
    [SerializeField] LayerMask _obstacleMask;

    [SerializeField] float _speed = 0f;
    [SerializeField] Transform _player;
    [SerializeField] Transform _monster;
    [SerializeField] Animator _wolf;

    int _damage = 60;
    float _lastHitTime = 0;
    List<Collider> _hitTargetList = new List<Collider>();
    private void Start()
    {
        _lastHitTime = Time.realtimeSinceStartup; // Time.realtimeSinceStartUp은 게임 시작부터 현재까지
                                                  // 진행된 모든 시간을 저장한 값
        FSM fsm = GetComponent<FSM>();
        fsm.SetMoveSpeed(_speed);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (_lastHitTime + 2 > Time.realtimeSinceStartup) // 현재 시간 보다 lastHitTime + 2가 더 클 경우 밑에 실행x
        {                                                // 즉, 2초마다 플레이어에게 _damage를 준다.
            return;
        }
        if (collision.collider.CompareTag("Player"))
        {
            _lastHitTime = Time.realtimeSinceStartup;
            PlayerStat.Instance.GetComponent<PlayerStat>().MonsterAttack(_damage);
            Debug.Log("플레이어에게" + _damage + "데미지가 들어갑니다.");
        }
    }
    public Transform GetTarget() => _player.transform;
    void FollowPlayer()
    {
        Vector3 moveVector = (_player.position - _monster.position);
        Vector3 dirVector = moveVector.normalized;
        Vector3 lastVector = dirVector * _speed;
        _monster.position = _monster.position + lastVector * Time.deltaTime;
        GetComponent<MonsterFSM>().ChangeStateByEnum(MonsterState.AttackMove);
        Debug.Log("AttackMove 실행 !");
        _monster.LookAt(_player);
    }
    private void OnDrawGizmos()
    {
        Vector3 myPos = transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(myPos, _viewRadius);

        float lookingAngle = transform.eulerAngles.y;  //캐릭터가 바라보는 방향의 각도
        Vector3 rightDir = AngleToDir(transform.eulerAngles.y + _viewAngle * 0.5f);
        Vector3 leftDir = AngleToDir(transform.eulerAngles.y - _viewAngle * 0.5f);
        Vector3 lookDir = AngleToDir(lookingAngle);

        Debug.DrawRay(myPos, rightDir * _viewRadius, Color.blue);
        Debug.DrawRay(myPos, leftDir * _viewRadius, Color.blue);
        Debug.DrawRay(myPos, lookDir * _viewRadius, Color.cyan);

        _hitTargetList.Clear();
        Collider[] targets = Physics.OverlapSphere(myPos, _viewRadius, _targetMask);

        if (targets.Length == 0) return;
        foreach (Collider enemyColli in targets)
        {
            Vector3 targetPos = enemyColli.transform.position;
            Vector3 targetDir = (targetPos - myPos).normalized;
            float targetAngle = Mathf.Acos(Vector3.Dot(lookDir, targetDir)) * Mathf.Rad2Deg;
            if (targetAngle <= _viewAngle * 0.5f && !Physics.Raycast(myPos, targetDir, _viewRadius, _obstacleMask))
            {
                _hitTargetList.Add(enemyColli);
                Debug.DrawLine(myPos, targetPos, Color.red);
                float distance = Vector3.Distance(gameObject.transform.position, enemyColli.transform.position);
                if(distance > 0.5f)
                {
                    FollowPlayer();
                }
            }
        }
    }
    Vector3 AngleToDir(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), 0f, Mathf.Cos(radian));
    }
}

public class Sensor
{
    public bool CanSeePlayer { get; private set; }
    public Vector3 PlayerPosition { get; private set; }
}

