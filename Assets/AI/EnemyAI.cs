using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyAI : MonoBehaviour
{
    GameObject target;

    bool[] hasAttacked;
    double attackTime = 0.27*3;
    double[] Timer;
    public List<GameObject> ghouls = new List<GameObject>();
    public List<EnemyController> ghoulControllers = new List<EnemyController>();
    // Use this for initialization
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Chase(ghouls, target);
        }
        Idle();
        Die();
    }
    
    void Initialize()
    {
        Timer = new double[ghouls.Capacity];
        hasAttacked = new bool[ghouls.Capacity];
        for (int i = 0; i < Timer.Length; i++)
        {
            Timer[i] = attackTime;
            hasAttacked[i] = false;
        }
        foreach(GameObject ghoul in ghouls)
        {
            ghoulControllers.Add(ghoul.GetComponent<EnemyController>());
            if (ghoul.GetComponent<EnemyController>().GetGhoulAnimator() == null)
                Debug.Log("get component enemycontroll null");
            ghoul.GetComponent<EnemyController>().GetGhoulAnimator().SetFloat("speed", 0);
        }
    }
    void Chase(List<GameObject> enemy, GameObject samurai)
    {
        for (int index = 0; index < ghouls.Capacity; index++)
        {
            // Test if the distance between the agent and the player
            // is less than the attack range (or the stoppingDistance parameter)
            if (Vector3.Distance(ghouls[index].transform.position, samurai.transform.position) < 1.3)
            {
                // If the agent is in attack range, become an obstacle and
                // disable the NavMeshAgent component
                if (ghoulControllers[index].GetGhoulAgent().enabled == true)
                {
                    ghoulControllers[index].GetGhoulAnimator().SetBool("attack", true);
                    ghoulControllers[index].GetGhoulAnimator().SetFloat("speed", 0);
                }
                if (ghoulControllers[index].GetGhoulAnimator().GetBool("attack") == true && ghoulControllers[index].GetGhoulAnimator().GetFloat("speed") == 0)
                {
                    Attack(ref Timer[index], ref hasAttacked[index], samurai, ghouls[index]);
                }
                ghoulControllers[index].GetGhoulAgent().enabled = false;
                ghoulControllers[index].GetGhoulObstacle().enabled = true;
            }
            else
            {
                // If we are not in range, become an agent again
                ghoulControllers[index].GetGhoulObstacle().enabled = false;
                ghoulControllers[index].GetGhoulAgent().enabled = true;

                ghoulControllers[index].GetGhoulAgent().destination = samurai.transform.position;
                ghoulControllers[index].GetGhoulAnimator().SetBool("attack", false);
                ghoulControllers[index].GetGhoulAnimator().SetFloat("speed", 5);
            }
        }

    }
    void Attack(ref double time, ref bool attacked, GameObject samurai, GameObject ghoul)
    {
        time -= Time.deltaTime;
        
        if (time < attackTime/3 && attacked == false)
        {
            samurai.GetComponent<CharacterStats>().SufferDamage(ghoul.GetComponent<CharacterStats>().attackDamage);
            attacked = true;
        }
        if (time < 0)
        {
    
            time = attackTime;
            attacked = false;
        }
    }
    public void SetTarget(GameObject _target)
    {
        target = _target;
    }
    public void ReturnToOriginalPosition()
    {
        target = null;
        foreach(EnemyController ghoul in ghoulControllers)
        {
            if (ghoul.GetGhoulAgent() != null)
                ghoul.GetGhoulAgent().SetDestination(ghoul.GetGhoulOriginalPosition());
        }
    }
    public void Idle()
    {
        foreach (EnemyController ghoul in ghoulControllers)
        {
            if (Vector3.Distance(ghoul.gameObject.transform.position, ghoul.GetGhoulOriginalPosition()) < 1)
            {
                ghoul.GetGhoulAnimator().SetBool("attack", false);
                ghoul.GetGhoulAnimator().SetFloat("speed", 0);
            }
        }
    }
    void Die()
    {
        foreach (EnemyController ghoul in ghoulControllers)
        {

            if (ghoul.GetGhoulStats().getCurHealth() <= 0)
            {
                ghoul.GetGhoulAnimator().SetBool("die", true);
            }

        }
    }
}
