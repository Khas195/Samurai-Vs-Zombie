using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;

public abstract class Command {
    abstract public void Execute();
    protected cData info;
    
    public void setCommandInfo(cData package) 
    {
        info = package;
    }
}
