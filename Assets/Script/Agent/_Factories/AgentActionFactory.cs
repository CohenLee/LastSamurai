using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AgentActionFactory
{
    /// <summary>
    /// AgentAction 类型枚举， 工厂根据该枚举类型创建AgentAction对象
    /// </summary>
    public enum E_Type
    {
        E_Idle,
        E_Move,
        E_Attack,
        E_Weapon_Show,
        E_Play_Anim,
        E_Count

    }

    static private Queue<AgentAction>[] _UnusedActions =new Queue<AgentAction>[(int)E_Type.E_Count];


#if DEBUG
    static private List<AgentAction> _ActiveActions = new List<AgentAction>();
#endif
    static AgentActionFactory() 
    {
        for (int i = 0; i < (int)E_Type.E_Count; i++)
        {
            _UnusedActions[i] = new Queue<AgentAction>();
        }
    }

    static public AgentAction Create(E_Type _type) 
    {
        int index = (int)_type;
        AgentAction a=null;
        if (_UnusedActions[index].Count > 0)
        {
            //Dequeue 表示移除
            a = _UnusedActions[index].Dequeue();
        }
        else
        {
            switch (_type)
            {
                case E_Type.E_Idle:
                    a = new AgentActionIdle();
                    break;
                case E_Type.E_Move:
                    a = new AgentActionMove();
                    break;
                //case E_Type.E_Attack:
                //    break;
                //case E_Type.E_Weapon_Show:
                //    break;
                //case E_Type.E_Play_Anim:
                //    break;
                //case E_Type.E_Count:
                //    break;
                default:
                    Debug.Log("没有AgentAction被创建" + _type.ToString());
                    break;
            }
        }

        a.Reset();
        a.SetActive();
#if DEBUG
        _ActiveActions.Add(a);
#endif
        return a;

    }

    public static void Return(AgentAction _action) 
    {
        _action.SetUnused();
        _UnusedActions[(int)_action.Type].Enqueue(_action); //Enqueue 表示添加
#if DEBUG
        _ActiveActions.Remove(_action);
#endif
    }


#if DEBUG
    static public void Report() 
    {
        Debug.Log("被激活的actions ：" + _ActiveActions.Count);
        for (int i = 0; i < _ActiveActions.Count; i++)
        {
            Debug.Log(_ActiveActions[i].Type);
            
        }
    }
#endif
}
