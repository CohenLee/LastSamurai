using UnityEngine;
using System.Collections;

public class AnimFSMPlayer :AnimFSM
{


    enum E_animState
    {
        E_Idle,
        E_Move,
        E_Attack
    }
    public AnimFSMPlayer(Animation _anims, Agent _owner) : base(_anims, _owner) 
    {

    }

    public override void Initialize()
    {
        //To do add anim state
        //添加角色状态到列表
        AnimStates.Add(new AnimStateIdle(AnimEngine,Owner));
        AnimStates.Add(new AnimStateMove(AnimEngine, Owner));

        DefaultAnimState = AnimStates[(int)E_animState.E_Idle];
        base.Initialize();

    }

    public override void DoAction(AgentAction _action)
    {
        if (CurrentAnimState.HandleNewAction(_action))
        {
            NextAnimState = null;
        }
        else
        {
            //根据AgentAction选择下一个状态
            if (_action is AnimStateIdle)
            {
                NextAnimState = AnimStates[(int)E_animState.E_Idle];
            }
            else if(_action is AnimStateMove)
            {
                NextAnimState = AnimStates[(int)E_animState.E_Move];
            }
            else
	        {
                Debug.Log(" none state");
	        }
            if (NextAnimState!=null)
            {
                ProgressToNextStage(_action);
            }
        }
    }
}
