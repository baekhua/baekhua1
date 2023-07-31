using UnityEngine;

public class AggressiveMonster : MonsterStat
{
    [SerializeField] Transform _player;
    [SerializeField] Transform _monster;
    float _speed = 1;

    int _damage = 6;
    float _lastHitTime = 0;
    private void Start()
    {
        _lastHitTime = Time.realtimeSinceStartup; // Time.realtimeSinceStartUp은 게임 시작부터 현재까지
                                                  // 진행된 모든 시간을 저장한 값
    }
    private void OnCollisionStay(Collision collision)
    {
        if(_lastHitTime + 2 > Time.realtimeSinceStartup) // 현재 시간 보다 lastHitTime + 2가 더 클 경우 밑에 실행x
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

    void Update()
    {
        if(_monster != null)
        {
            if(Vector3.Distance(_player.position, _monster.position) < 50)
            {
                FollowPlayer();
            }
        }
        
        // 시야 안에 플레이어가 감지되면 플레이어를 따라온다.
        // 1. 시야각
        // 2. 레이
    }
    void FollowPlayer()
    {
        Vector3 moveVector = (_player.position - _monster.position);
        Vector3 dirVector = moveVector.normalized;
        Vector3 lastVector = dirVector * _speed;
        _monster.position = _monster.position + lastVector * Time.deltaTime;
        _monster.LookAt(_player);
    }
}
