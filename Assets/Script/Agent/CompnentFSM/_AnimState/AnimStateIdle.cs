using UnityEngine;
using System.Collections;

public class AnimStateIdle : AnimState {

    float TimeToFinishWeaponAction;
    AgentAction WeaponAction;

    public AnimStateIdle(Animation _anims, Agent _owner) : base(_anims, _owner) 
    {

    }

    public override bool HandleNewAction(AgentAction _action)
    {
        if (_action is AgentActionShowWeapon)
        {
            if ((_action as AgentActionShowWeapon).Show==true)
            {
                //to do: 显示武器
            }
            else
            {
                //to do:  隐藏武器
            }
            WeaponAction = _action;
            return true;
        }
        return false;
    }

    public override void Update()
    {
        if (WeaponAction!=null&&TimeToFinishWeaponAction<Time.timeSinceLevelLoad)
        {
            WeaponAction.SetSuccess();
            WeaponAction = null;
            PlayIdleAnim();
        }
    }

    void PlayIdleAnim()
    {

    }
    public override void Release()
    {
        SetFinished(true);
    }

    protected override void Initialize(AgentAction _action)
    {
        base.Initialize(_action);

        //// 设置角色数据，运动状态，移动方向，移动速度
        //Owner.BlackBoard.MotionType = E_MotionType.None;
        //Owner.BlackBoard.MoveDir = Vector3.zero;
        //Owner.BlackBoard.Speed = 0;
		
        if (WeaponAction==null)
        {
            PlayIdleAnim();
        }
    }
}
