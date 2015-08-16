using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public class DoubleShot : Ability {
    

    public override void ExecuteAbility(cData package)
    {
        setupAbilityRange();
        Unit mUnit = package.GetValue<Unit>("UNIT");
        Unit enemy = package.GetValue<Unit>("ENEMY");
        Vector3 enemyLocation = package.GetValue<Vector3>("ENEMYLOCATION");
        NavMeshAgent agent = mUnit.getNavMeshAgent();
        float distanceBetweenMyUnitAndEnemy = Vector3.Distance(enemyLocation, agent.gameObject.transform.position);
        if (abilityRange >= distanceBetweenMyUnitAndEnemy)
        {
            if (mUnit.getDamage() - enemy.getDefense() > 0)
                enemy.setHealth(enemy.getHealth() - (mUnit.getDamage() - enemy.getDefense()));

        }
    }
    public void setupAbilityRange()
    {
        abilityRange = 5;
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
