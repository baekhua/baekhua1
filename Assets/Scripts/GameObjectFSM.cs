using Unity.VisualScripting;
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
//public class MonsterIdle : GameObjectFSMState
//{

//}
//public class MonsterPatrol : GameObjectFSMState
//{

//}
//public class MonsterAttack : GameObjectFSMState
//{

//}
//public class MonsterAttackMove : GameObjectFSMState
//{

//}
//public class MonsterDie : GameObjectFSMState
//{

//}


