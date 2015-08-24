using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public class StandGround : Ability {
    private static StandGround instance = new StandGround();

    private StandGround() { }
    public static StandGround getInstance()
    {
        return instance;
    }
    public override void ExecuteAbility(cData package)
    {
        Debug.Log("execute stand ground");
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
        Debug.Log("check requirement standground");
        Unit mUnit = self.GetComponent<Unit>();
        if (mUnit.GetMana() < 2)
        {
            Debug.Log("not enough mana");
            return false;
        }
        return true;
    }
}
