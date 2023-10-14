using UnityEngine;

public abstract class GameObjectFSM : MonoBehaviour
{
    GameObjectFSMState _currentState;
    public void ChangeState(GameObjectFSMState nextStage)
    {
        _currentState?.OnExit();
        _currentState = nextStage;
        _currentState?.OnEnter();
    }
    private void Update()
    {
        _currentState?.DoLoop();
    }
}
public abstract class GameObjectFSMState
{
    protected GameObject _obj;
    public GameObjectFSMState(GameObject obj) => _obj = obj;
    public abstract void OnEnter();
    public abstract void DoLoop();
    public abstract void OnExit();
}
public class MonsterIdle : GameObjectFSMState
{
    FSM _fsm;
    MonsterFSM _monsterFSM;
    public MonsterIdle(GameObject obj) : base(obj) { }
    float _timer;
    public override void DoLoop()
    {
        CheckTransition();
    }
    void CheckTransition()
    {
        _timer += Time.deltaTime;
        if (_timer > 1)
        {
            _monsterFSM.ChangeStateByEnum(MonsterState.Patrol);
        }
    }
    public override void OnEnter()
    {
        _timer = 0;
        _fsm = _obj.GetComponent<FSM>();
        _monsterFSM = _obj.GetComponent<MonsterFSM>();
        //_fsm.StartAnim("Idle");
    }
    public override void OnExit()
    {

    }
}
public class MonsterPatrol : GameObjectFSMState
{
    FSM _fsm;
    MonsterFSM _monsterFSM;
    float _moveSpeed;
    Vector3 _targetPos;
    Transform _targetTransform;
    bool _isEndPoint = false;
    public MonsterPatrol(GameObject obj) : base(obj) { }
    public override void DoLoop()
    {
        _obj.transform.LookAt(_targetPos);
        _obj.transform.position += (_targetPos - _obj.transform.position).normalized * _moveSpeed * Time.deltaTime;
        CheckTransition();
    }
    void CheckTransition()
    {
        if(Vector3.Distance(_targetPos, _obj.transform.position) < 0.5f)
        {
            _isEndPoint = true;
            _monsterFSM.ChangeStateByEnum(MonsterState.Idle);
        }
        //if(Vector3.Distance(_targetTransform.position, _obj.transform.position) < 10)
        //{
        //    _monsterFSM.ChangeStateByEnum(MonsterState.AttackMove);
        //}
    }
    public override void OnEnter()
    {
        _fsm = _obj.GetComponent<FSM>();
        _monsterFSM = _obj.GetComponent<MonsterFSM>();
        _moveSpeed = _fsm.GetMoveSpeed();
        _targetPos = _fsm.GetNowPatPoint().position;
        _targetTransform = _fsm.GetTargetTrans();
        _fsm.StartAnim("Patrol");
        _isEndPoint = false;
    }
    public override void OnExit()
    {
        if (_isEndPoint == true) _fsm.AddPatIdx();
    }
}
public class MonsterAttack : GameObjectFSMState
{
    FSM _fsm;
    MonsterFSM _monsterFSM;
    Transform _target;
    public MonsterAttack(GameObject obj) : base(obj) { }
    public override void OnEnter()
    {
        _fsm = _obj.GetComponent<FSM>();
        _monsterFSM = _obj.GetComponent<MonsterFSM>();
        _target = _fsm.GetTargetTrans();
        _fsm.StartAnim("Attack");
        _monsterFSM.SetAnimStateCallback(() => _monsterFSM.ChangeStateByEnum(MonsterState.AttackMove));
    }
    public override void DoLoop()
    {
        if(Vector3.Distance(_target.transform.position, _obj.transform.position) > 3)
        {
            _monsterFSM.ChangeStateByEnum(MonsterState.Idle);
        }
    }
    public override void OnExit()
    {
        
    }
}
public class MonsterAttackMove : GameObjectFSMState
{
    FSM _fsm;
    MonsterFSM _monsterFSM;
    Transform _targetTrans;
    float _attackMoveSpeed;
    public MonsterAttackMove(GameObject obj) : base(obj) { }
    public override void OnEnter()
    {
        _fsm = _obj.GetComponent<FSM>();
        _monsterFSM = _obj.GetComponent<MonsterFSM>();
        _attackMoveSpeed = _fsm.GetAttackMoveSpeed();
        _targetTrans = _fsm.GetTargetTrans();
    }
    public override void DoLoop()
    {
        //_obj.transform.position += (_targetTrans.position - _obj.transform.position).normalized * _attackMoveSpeed * Time.deltaTime;
        CheckTransition();
    }
    void CheckTransition()
    {
        if (Vector3.Distance(_targetTrans.position, _obj.transform.position) < 2f)
        {
            _monsterFSM.ChangeStateByEnum(MonsterState.Attack);
        }
        if (Vector3.Distance(_targetTrans.transform.position, _obj.transform.position) > 10f)
        {
            _monsterFSM.ChangeStateByEnum(MonsterState.Idle);
        }
    }
    public override void OnExit()
    {
        _obj.GetComponent<AggressiveMonster>().ResetAnimBool();
    }
}
public class MonsterDamage : GameObjectFSMState
{
    FSM _fsm;
    MonsterFSM _monsterFSM;
    public MonsterDamage(GameObject obj) : base(obj) { }
    public override void OnEnter()
    {
        _fsm = _obj.GetComponent<FSM>();
        _fsm.StartAnim("Damage");
    }
    public override void DoLoop()
    {

    }
    public override void OnExit()
    {

    }
}
public class MonsterDie : GameObjectFSMState
{
    FSM _fsm;
    MonsterFSM _monsterFSM;
    public MonsterDie(GameObject obj) : base(obj) { }
    public override void OnEnter()
    {
        _fsm = _obj.GetComponent<FSM>();
        _monsterFSM = _obj.GetComponent<MonsterFSM>();
        _fsm.StartAnim("Die");
        _monsterFSM.SetAnimStateCallback(OnExit);
    }
    public override void DoLoop()
    {

    }
    public override void OnExit()
    {
        GameObject.Destroy(_obj);
    }
}


