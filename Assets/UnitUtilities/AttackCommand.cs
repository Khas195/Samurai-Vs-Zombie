using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public class AttackCommand : Command
{
    


    public override void Execute()
    {
        Debug.Log("attack");
        if (info == null)
        {
            Debug.Log("AttackCommand has not set info");
            return;
        }

        GameObject self = info.GetValue<GameObject>("SELF");
        Unit mUnit = self.GetComponent<Unit>();
        GameObject target = info.GetValue<GameObject>("TARGET");
        Debug.Log(target.gameObject.name);
        Unit targetUnit = target.GetComponent<Unit>();
        Vector3 targetLocation = target.gameObject.transform.position;
        NavMeshAgent agent = mUnit.GetNavMeshAgent();
        float distanceBetweenMyUnitAndEnemy = Vector3.Distance(targetLocation, agent.gameObject.transform.position);
        if (mUnit.GetAttackRange() >= distanceBetweenMyUnitAndEnemy)
        {
            if (mUnit.GetDamage() - targetUnit.GetDefense() > 0)
            {
                targetUnit.SetHealth(targetUnit.GetHealth() - (mUnit.GetDamage() - targetUnit.GetDefense()));
                Debug.Log("enemy remaining health " + targetUnit.GetHealth());
            }
            
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