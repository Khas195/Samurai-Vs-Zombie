using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public abstract class Ability {
    protected float abilityRange;
    abstract public void ExecuteAbility(cData package);
    abstract public float getAbilityRange();
    abstract public bool needToShowRange();


}
