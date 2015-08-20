using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public class MoveCommand : Command
{
    
    
    public override void Execute()
    {
        if (info == null)
        {
            Debug.Log("MOve Command has not set info");
            return;
        }
        Unit mUnit = info.GetValue<Unit>("UNIT");
        Vector3 destination = info.GetValue<Vector3>("DESTINATION");
        mUnit.getNavMeshAgent().SetDestination(destination);
        cData.ReturnPackage(info);
    }
}