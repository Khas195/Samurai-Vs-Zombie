using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public class DoubleShot : Ability {
    

    public void ExecuteAbility(cData package)
    {
        base.ExecuteAbility(package);
        GameObject self = package.GetValue<GameObject>("SELF");
        Unit mUnit = self.GetComponent<Unit>();
        GameObject target = package.GetValue<GameObject>("TARGET");
        Unit targetUnit = target.GetComponent<Unit>();
        Vector3 enemyLocation = targetUnit.gameObject.transform.position;
        NavMeshAgent agent = mUnit.GetNavMeshAgent();
        float distanceBetweenMyUnitAndEnemy = Vector3.Distance(enemyLocation, agent.gameObject.transform.position);
        if (abilityRange >= distanceBetweenMyUnitAndEnemy)
        {
            Debug.Log("ENEmy health " + targetUnit.GetHealth());
            if (mUnit.GetDamage() - targetUnit.GetDefense() > 0)
            {
                targetUnit.SetHealth(targetUnit.GetHealth() - 2 * (mUnit.GetDamage() - targetUnit.GetDefense()));
                mUnit.SetMana(mUnit.GetMana() - 2);
            }
            Debug.Log("ENEmy health " + targetUnit.GetHealth());
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
