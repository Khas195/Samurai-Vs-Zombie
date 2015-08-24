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
        
        string unitType = info.GetValue<GameObject>("SELF").name.Split(' ')[0];
        if (unitType == "Knight")
            setAbility(StandGround.getInstance());
        else if (unitType == "Archer")
            setAbility(DoubleShot.getInstance());
        else if (unitType == "Healer")
            setAbility(Heal.getInstance());
        else
            Debug.Log(unitType);
        
        Debug.Log(ability.ToString());
        if (ability.CheckRequirement(info))
        {
            Debug.Log("finish check ability info");
            ability.ExecuteAbility(info);
            Debug.Log("finish execute ability");
        }
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
