using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;

public abstract class Command {
    abstract public void Execute();
    protected cData info;
    
    public void setCommandInfo(cData package) 
    {
        if (info == null)
            info = package;
        else
        {
            // UI cung cap
            if (info.GetValue<Unit>("ENEMY") == null)
                info.SetValue<Unit>("ENEMY", package.GetValue<Unit>("ENEMY"));
            if (info.GetValue<Unit>("ALLY") == null)
                info.SetValue<Unit>("ALLY", package.GetValue<Unit>("ALLY"));
            if (info.GetValue<Unit>("DESTINATION") == null)
                info.SetValue<Vector3>("DESTINATION", package.GetValue<Vector3>("DESTINATION"));
        }
    }
}
