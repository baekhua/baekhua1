using UnityEngine;

public class PlayerStat : GenericSingleton<PlayerStat>
{
    int _maxHp = 100;
    int _currentHp;
    int _stamina = 100;
    [SerializeField] GameObject _bowPrefab;
    GameObject _bow;
    private void Start()
    {
        _currentHp = _maxHp;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CreatBow();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            Time.timeScale = 0f;
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            Time.timeScale = 1f;
        }
    }
    public void CreatBow()
    {
        if(_bow == null)
        {
            _bow = Instantiate(_bowPrefab);
            if(_bow != null)
            {
                _bow.GetComponent<Bow>().Equip();
            }
        }
    }
    public void MonsterAttack(int damage)
    {
        _currentHp = _currentHp - damage;
        if (_currentHp <= 0) Die();
        //Debug.Log(_hp);
    }
    public void Run(int running)
    {
        _stamina = _stamina - running;
    }
    void Die()
    {
        //Destroy(gameObject);
        Debug.Log("플레이어가 죽었습니다. ");
    }
}
