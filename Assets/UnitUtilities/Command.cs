using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
using System.Collections.Generic;

public abstract class Command {
    abstract public void Execute();
    protected cData info;
    
    public void setCommandInfo(cData package) 
    {
        if (info == null)
        {
            info = package;
            Debug.Log("package = null");
        }
        else
            info.AddAllValueFromAnotherPackage(package); 
    }
    abstract public bool CheckRequirement();
}
