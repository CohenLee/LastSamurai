using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimState :System.Object
{
    protected Animation AnimEngine;
    protected Agent Owner;
    /// <summary>
    /// 角色对象Transfrom
    /// </summary>
    protected Transform Transform;

    /// <summary>
    /// 角色骨骼根节点Transfrom
    /// </summary>
    protected Transform RootTransform;
    /// <summary>
    /// 角色动画是否完成
    /// </summary>
    private bool m_IsFinished = true;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_anims"></param>
    public AnimState(Animation _anims,Agent _owner) 
    {
        AnimEngine = _anims;
        Owner = _owner;
        Transform = Owner.transform;
        RootTransform = Transform.Find("root");
    }

    /// <summary>
    /// 初始化创建状态
    /// </summary>
    protected virtual void Initialize(AgentAction _action) 
    {

    }

    /// <summary>
    /// 激活这个状态
    /// </summary>
    public virtual void OnActivate(AgentAction _action) 
    {

    }

    /// <summary>
    /// 禁用状态
    /// </summary>
    public virtual void OnDeactivate() 
    {

    }

    public virtual bool IsFinished() 
    {
        return m_IsFinished;
    }
    
    public virtual void SetFinished(bool _finished)
    {
        m_IsFinished = _finished;
    }


    public virtual void Update()
    {

    }


    public virtual void Release()
    {

    }
    public virtual bool HandleNewAction(AgentAction _action) 
    {
        return false;
    }
}
