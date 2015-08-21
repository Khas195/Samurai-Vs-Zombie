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

        ability.ExecuteAbility(info);
        cData.ReturnPackage(info);
    }

    
}
