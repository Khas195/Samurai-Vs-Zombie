﻿using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
using System.Collections.Generic;

public abstract class Command {
    abstract public void Execute();
    protected cData info;
    
    public void setCommandInfo(cData package) 
    {
        if (info == null)
            info = package;
        else
            info.AddAllValueFromAnotherPackage(package);
        
    }
}
