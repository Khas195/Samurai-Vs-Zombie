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
            info.SetValue<Unit>("UNIT", info.GetValue<Unit>("UNIT"));
            // UI cung cap enemy voi ally
            info.SetValue<Unit>("ENEMY", info.GetValue<Unit>("ENEMY"));
            info.SetValue<Unit>("ALLY", info.GetValue<Unit>("ALLY"));
        }
    }
}
