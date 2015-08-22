using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public class AbilityCommand : Command {
    

    protected Ability ability;
    public void setAbility(Ability _ability)
    {
        ability = _ability;
    }
    public override void Execute()
    {
        if (info == null)
        {
            Debug.Log("Ability Command has not set info");
            return;
        }
        
        //for test
        //setAbility(new StandGround());
        ability.CheckRequirement(info);
        ability.ExecuteAbility(info);
        cData.ReturnPackage(info);
    }
    public override bool CheckRequirement()
    {
        if (info.GetValue<GameObject>("SELF") == null)
        {
            Debug.Log("can not get info value self");
            return false;
        }
        else if (info.GetValue<GameObject>("TARGET") == null)
        {
            Debug.Log("can not get info value target");
            return false;
        }
        return true;
    }

    
}
