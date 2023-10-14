using UnityEngine;

public class MonsterStat : MonoBehaviour
{
    int _maxHp = 100;
    int _currentHp = 0;
    float _timer;
    void Start()
    {
        _currentHp = _maxHp;
    }
    public void TakeDamege(int damage)
    {
        _currentHp -= damage;

        if (_currentHp <= 0)
        {
            GetComponent<MonsterFSM>().ChangeStateByEnum(MonsterState.Die);
            _timer += Time.deltaTime;
            if (_timer > 1)
            {
                Destroy(gameObject);
                _timer = 0;
            }
        }
    }
}
