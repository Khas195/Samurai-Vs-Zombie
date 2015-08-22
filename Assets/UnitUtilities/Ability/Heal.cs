using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public class Heal : Ability {
    

    public void ExecuteAbility(cData package)
    {
        base.ExecuteAbility(package);
        GameObject self = package.GetValue<GameObject>("SELF");
        Unit mUnit = self.GetComponent<Unit>();
        GameObject target = package.GetValue<GameObject>("TARGET");
        Unit targetUnit = target.GetComponent<Unit>();
        Vector3 allyLocation = targetUnit.gameObject.transform.position;
        NavMeshAgent agent = mUnit.GetNavMeshAgent();
        float distanceBetweenMyUnitAndAlly = Vector3.Distance(allyLocation, agent.gameObject.transform.position);
        if (abilityRange >= distanceBetweenMyUnitAndAlly)
        {
            Debug.Log("Before heal: " + targetUnit.GetHealth());
            targetUnit.SetHealth(targetUnit.GetHealth() + mUnit.GetDamage());
            mUnit.SetMana(mUnit.GetMana() - 2);
            Debug.Log("After heal: " + targetUnit.GetHealth());
        }
        
    }
    public override void SetupAbilityRange()
    {
        abilityRange = 10;
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
