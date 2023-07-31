using UnityEngine;

public class MonsterStat : GenericSingleton<MonsterStat>
{
    int _maxHp = 100;
    int _currentHp = 0;
    void Start()
    {
        _currentHp = _maxHp;
    }
    public void TakeDamege(int damage)
    {
        _currentHp = _currentHp - damage;
    }
}
