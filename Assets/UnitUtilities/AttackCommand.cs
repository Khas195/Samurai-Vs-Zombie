using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public class AttackCommand : Command
{
    


    public override void Execute()
    {
        if (info == null)
        {
            Debug.Log("AttackCommand has not set info");
            return;
        }

        Unit mUnit = info.GetValue<Unit>("UNIT");
        Unit enemy = info.GetValue<Unit>("ENEMY");
        Vector3 enemyLocation = enemy.gameObject.transform.position;
        NavMeshAgent agent = mUnit.getNavMeshAgent();
        float distanceBetweenMyUnitAndEnemy = Vector3.Distance(enemyLocation, agent.gameObject.transform.position);
        if (mUnit.getAttackRange() >= distanceBetweenMyUnitAndEnemy)
        {
            if (mUnit.getDamage() - enemy.getDefense() > 0)
            {
                enemy.setHealth(enemy.getHealth() - (mUnit.getDamage() - enemy.getDefense()));
                Debug.Log("enemy remaining health " + enemy.getHealth());
            }
            
        }
        cData.ReturnPackage(info);
    }
}