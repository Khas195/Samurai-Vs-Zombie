using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public abstract class Ability {
    protected float abilityRange;
    public void ExecuteAbility(cData package)
    {
        SetupAbilityRange();
    }
    
    abstract public bool CheckRequirement(cData package);
    abstract public void SetupAbilityRange();
    
    public float GetAbilityRange()
    {
        SetupAbilityRange();
        return abilityRange;
    }
    public bool NeedToShowRange()
    {
        SetupAbilityRange();
        if (abilityRange == 0)
        {
            return false;
        }
        return true;
    }
    
}
