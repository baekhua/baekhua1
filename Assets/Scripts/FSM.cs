using UnityEngine;

public class FSM : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Transform[] _patPoints;
    [SerializeField] float _attackMoveSpeed;
    float _speed;

    int _patIdx = 0;
    void Start()
    {
        GetComponent<MonsterFSM>().ChangeStateByEnum(MonsterState.Idle);
    }
    public void StartAnim(string AniName)
    {
        //GetComponent<Animator>().Play("breathes");
        if (AniName.Equals("Attack"))
        {
            GetComponent<Animator>().SetTrigger("Attack1");
            Debug.Log("Attack �� ����˴ϴ�.");
        }
        else if (AniName.Equals("Idle"))
        {
            GetComponent<Animator>().Play("breathes");
            Debug.Log("Idle �� ����˴ϴ�.");
        }
        else if(AniName.Equals("Die"))
        {
            GetComponent<Animator>().SetTrigger("Die");
            Debug.Log("Die �� ����˴ϴ�.");
        }
        else if(AniName.Equals("Patrol"))
        {
            GetComponent<Animator>().SetTrigger("Walk");
            Debug.Log("Walk �� ����˴ϴ�.");
        }
        else if(AniName.Equals("Damage"))
        {
            GetComponent<Animator>().SetTrigger("Damage");
            Debug.Log("Damage �� ����˴ϴ�.");
        }
        else if(AniName.Equals("AttackMove"))
        {
            GetComponent<Animator>().SetTrigger("Run");
            Debug.Log("AttackMove �� ����˴ϴ�.");
        }
        else
        {
            Debug.Log($"State���� {AniName} �ִϸ��̼��� �����߽��ϴ�. ");
        }
    }
    public Transform GetTargetTrans() => _target;
    public Transform GetNowPatPoint() => _patPoints[_patIdx];
    public float GetMoveSpeed() => _speed;
    public void SetMoveSpeed(float speed) => _speed = speed;
    public float GetAttackMoveSpeed() => _attackMoveSpeed;
    public void AddPatIdx()
    {
        _patIdx++;
        if(_patIdx >= _patPoints.Length) _patIdx = 0;
    }
}
