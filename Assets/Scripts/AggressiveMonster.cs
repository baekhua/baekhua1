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
        _lastHitTime = Time.realtimeSinceStartup; // Time.realtimeSinceStartUp�� ���� ���ۺ��� �������
                                                  // ����� ��� �ð��� ������ ��
    }
    private void OnCollisionStay(Collision collision)
    {
        if(_lastHitTime + 2 > Time.realtimeSinceStartup) // ���� �ð� ���� lastHitTime + 2�� �� Ŭ ��� �ؿ� ����x
        {                                                // ��, 2�ʸ��� �÷��̾�� _damage�� �ش�.
            return;
        }
        if (collision.collider.CompareTag("Player"))
        {
            _lastHitTime = Time.realtimeSinceStartup;
            PlayerStat.Instance.GetComponent<PlayerStat>().MonsterAttack(_damage);
            Debug.Log("�÷��̾��" + _damage + "�������� ���ϴ�.");
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
        
        // �þ� �ȿ� �÷��̾ �����Ǹ� �÷��̾ ����´�.
        // 1. �þ߰�
        // 2. ����
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
