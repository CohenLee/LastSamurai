using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AnimFSM
{
    /// <summary>
    /// 该状态机所有状态列表，子类Initialize内初始化改列表
    /// </summary>
    protected List<AnimState> AnimStates;

    /// <summary>
    /// 当前状态
    /// </summary>
    protected AnimState CurrentAnimState;

    /// <summary>
    /// 下一个状态
    /// </summary>
    protected AnimState NextAnimState;

    /// <summary>
    /// 默认状态
    /// </summary>
    protected AnimState DefaultAnimState;

    protected Animation AnimEngine;
    protected Agent Owner;

    public AnimFSM(Animation _anims,Agent _owner)
    {
        AnimEngine = _anims;
        Owner = _owner;
        AnimStates = new List<AnimState>();
    }

    public virtual void Initialize()
    {
        CurrentAnimState = DefaultAnimState;
        CurrentAnimState.OnActivate(null);
        NextAnimState = null;
    }

    public void Update() 
    {
        if (CurrentAnimState.IsFinished())
        {
            CurrentAnimState.OnDeactivate();
            CurrentAnimState = DefaultAnimState;
            CurrentAnimState.OnActivate(null);
        }
        CurrentAnimState.Update();
    }
    /// <summary>
    /// 重置
    /// </summary>
    public void Reset() 
    {
        for (int i = 0; i < AnimStates.Count; i++)
        {
            if (AnimStates[i].IsFinished()==false)
            {
                AnimStates[i].OnDeactivate();
                AnimStates[i].SetFinished(true);
            }
        }
    }
    /// <summary>
    /// 子类实现该方法，每个角色在做一个操作时会传人操作对应的AgentAction.
    /// 该方法内执行状态切换和状态选择
    /// </summary>
    /// <param name="_action">_action.</param>
    public abstract void DoAction(AgentAction _action);


    /// <summary>
    /// 切换到下一个状态
    /// </summary>
    /// <param name="_action">_action.</param>
    protected void ProgressToNextStage(AgentAction _action)
    {
        if (NextAnimState!=null)
        {
            CurrentAnimState.Release();
            CurrentAnimState.OnDeactivate();

            CurrentAnimState = NextAnimState;
            CurrentAnimState.OnActivate(_action);

            NextAnimState = null;
        }
    }
}
