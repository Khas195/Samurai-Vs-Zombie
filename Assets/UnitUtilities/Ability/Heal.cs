using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public class Heal : Ability {
    

    public override void ExecuteAbility(cData package)
    {
        setupAbilityRange();
        Unit mUnit = package.GetValue<Unit>("UNIT");
        Unit ally = package.GetValue<Unit>("ALLY");
        Vector3 allyLocation = package.GetValue<Vector3>("ALLYLOCATION");
        NavMeshAgent agent = mUnit.getNavMeshAgent();
        float distanceBetweenMyUnitAndAlly = Vector3.Distance(allyLocation, agent.gameObject.transform.position);
        if (abilityRange >= distanceBetweenMyUnitAndAlly)
        {
            ally.setHealth(ally.getHealth() + mUnit.getDamage());
        }
    }
    public void setupAbilityRange()
    {
        abilityRange = 3;
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
