using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public class Unit : MonoBehaviour {

    public int health;
    public int mana;
    public float movement;
    public float attackRange;
    public int damage;
    public int defense;
    Command command;
    cData unitInfo;
    // UI assign
    //public GameObject enemy;
    //public GameObject ally;

    NavMeshAgent agent;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        /*temporary test
        if (enemy == null)
            return;
        if (ally == null)
            return;
        setCommand(new AttackCommand());
        ExecuteCommand();*/
    }
    void Update()
    {
        if (command != null)
            ExecuteCommand();
    }
    public cData GetInfo()
    {
        unitInfo = cData.CreatePackage();
        unitInfo.SetValue<Unit>("UNIT", this);
        // 2 dong nay de test, khi UI gui info dc r thi xoa di
        //unitInfo.SetValue<Unit>("ENEMY", enemy.GetComponent<Unit>());
        //unitInfo.SetValue<Unit>("ALLY", ally.GetComponent<Unit>());
        return unitInfo;
    }
    public void SetCommand(Command _command){
        command = _command;
        command.setCommandInfo(GetInfo());
    }
    public void ExecuteCommand(){
        if (command.CheckRequirement() == false)
            command = null;
        else
            command.Execute();
        cData.ReturnPackage(unitInfo);
    }
    public void SetHealth(int _health)
    {
        health = _health;
    }
    public int GetHealth()
    {
        return health;
    }

    public void SetMana(int _mana)
    {
        mana = _mana;
    }
    public int GetMana()
    {
        return mana;
    }

    public int GetDamage()
    {
        return damage;
    }
    public void SetDamage(int _damage)
    {
        damage = _damage;
    }

    public int GetDefense()
    {
        return defense;
    }
    public void SetDefense(int _defense)
    {
        defense = _defense;
    }

    public NavMeshAgent GetNavMeshAgent()
    {
        return agent;
    }

    public float GetAttackRange()
    {
        return attackRange;
    }

    public float GetMovement()
    {
        return movement;
    }
}
