using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public class StandGround : Ability {
    
    public void ExecuteAbility(cData package)
    {
        base.ExecuteAbility(package);
        GameObject self = package.GetValue<GameObject>("SELF");
        Unit mUnit = self.GetComponent<Unit>();
        Debug.Log("Defense " + mUnit.GetDefense());
        mUnit.SetDefense((int)(mUnit.GetDefense() * 1.5));
        mUnit.SetMana(mUnit.GetMana() - 2);
        Debug.Log("Defense " + mUnit.GetDefense());
    }
    public override void SetupAbilityRange()
    {
        abilityRange = 0;
    }
    public override bool CheckRequirement(cData package)
    {
        GameObject self = package.GetValue<GameObject>("SELF");
        Unit mUnit = self.GetComponent<Unit>();
        if (mUnit.GetMana() < 2)
            return false;
        return true;
    }
}
