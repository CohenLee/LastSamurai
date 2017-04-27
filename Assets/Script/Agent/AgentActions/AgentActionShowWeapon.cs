using UnityEngine;
using System.Collections;

public class AgentActionShowWeapon : AgentAction {

    public bool Show;

    public AgentActionShowWeapon() : base(AgentActionFactory.E_Type.E_Weapon_Show) 
    {

    }
}
