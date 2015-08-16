using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public class StandGround : Ability {
    
    public override void ExecuteAbility(cData package)
    {
        Unit mUnit = package.GetValue<Unit>("UNIT");
        mUnit.setDefense((int)(mUnit.getDefense() * 1.5));
    }
    public void setupAbilityRange()
    {
        abilityRange = 0;
    }
    public override float getAbilityRange()
    {
        setupAbilityRange();
        return abilityRange;
    }
    public override bool needToShowRange()
    {
        setupAbilityRange();
        if (abilityRange == 0)
        {
            return false;
        }
        return true;
    }
}
