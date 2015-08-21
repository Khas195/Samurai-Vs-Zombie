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
    public cData getInfo()
    {
        unitInfo = cData.CreatePackage();
        unitInfo.SetValue<Unit>("UNIT", this);
        // 2 dong nay de test, khi UI gui info dc r thi xoa di
        //unitInfo.SetValue<Unit>("ENEMY", enemy.GetComponent<Unit>());
        //unitInfo.SetValue<Unit>("ALLY", ally.GetComponent<Unit>());
        return unitInfo;
    }
    public void setCommand(Command _command){
        command = _command;
        command.setCommandInfo(getInfo());
    }
    public void ExecuteCommand(){
        command.Execute();
        cData.ReturnPackage(unitInfo);
    }
    public void setHealth(int _health)
    {
        health = _health;
    }
    public int getHealth()
    {
        return health;
    }

    public void setMana(int _mana)
    {
        mana = _mana;
    }
    public int getMana()
    {
        return mana;
    }

    public int getDamage()
    {
        return damage;
    }
    public void setDamage(int _damage)
    {
        damage = _damage;
    }

    public int getDefense()
    {
        return defense;
    }
    public void setDefense(int _defense)
    {
        defense = _defense;
    }

    public NavMeshAgent getNavMeshAgent()
    {
        return agent;
    }

    public float getAttackRange()
    {
        return attackRange;
    }

    public float getMovement()
    {
        return movement;
    }
}
