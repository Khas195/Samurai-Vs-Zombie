using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public class MoveCommand : Command
{
    
    
    public override void Execute()
    {
        if (CheckRequirement() == false)
        {
            Debug.Log("requirement false");
            return;
        }
        if (info == null)
        {
            Debug.Log("MOve Command has not set info");
            return;
        }
        GameObject self = info.GetValue<GameObject>("SELF");
        if (info.GetValue<GameObject>("SELF") == null)
            Debug.Log("abc");
        Unit mUnit = self.GetComponent<Unit>();
        GameObject target = info.GetValue<GameObject>("TARGET");
        Vector3 destination = target.transform.position;
        NavMeshAgent agent = mUnit.GetNavMeshAgent();
        float temp = agent.stoppingDistance;
        agent.stoppingDistance = 0;
        Debug.Log(destination.ToString());
        agent.SetDestination(destination);
        agent.stoppingDistance = temp;
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