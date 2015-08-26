using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyAI : MonoBehaviour
{
    public GameObject target;
    double[] animationTime;
    public List<GameObject> ghouls = new List<GameObject>();
    NavMeshAgent agent;
    NavMeshObstacle obstacle;
    // Use this for initialization
    void Start()
    {
        Initialize();


    }

    // Update is called once per frame
    void Update()
    {
        Chase(ghouls, target);
    }

    void Initialize()
    {
        for (int i = 1; i < 100; i++)
        {
            GameObject temp = GameObject.Find("ghoulprefab " + i);
            if (temp)
                ghouls.Add(temp);
            else
                break;
        }
        animationTime = new double[ghouls.Capacity];
        for (int i = 0; i < animationTime.Length; i++)
        {
            animationTime[i] = 0.9;
        }
            foreach (GameObject ghoul in ghouls)
            {
                ghoul.GetComponent<Animator>().SetFloat("speed", 5);
            }
    }
    void Chase(List<GameObject> enemy, GameObject samurai)
    {
        int index = 0;
        foreach (GameObject ghoul in enemy)
        {
            
            agent = ghoul.GetComponent<NavMeshAgent>();
            obstacle = ghoul.GetComponent<NavMeshObstacle>();


            // Test if the distance between the agent and the player
            // is less than the attack range (or the stoppingDistance parameter)
            if (Vector3.Distance(ghoul.transform.position, samurai.transform.position) < 1.3)
            {
                // If the agent is in attack range, become an obstacle and
                // disable the NavMeshAgent component
                if (agent.enabled == true)
                {

                    ghoul.GetComponent<Animator>().SetBool("attack", true);
                    ghoul.GetComponent<Animator>().SetFloat("speed", 0);
                }
                if (ghoul.GetComponent<Animator>().GetBool("attack") == true && ghoul.GetComponent<Animator>().GetFloat("speed") == 0)
                {
                    Attack(animationTime[index], samurai, ghoul);
                }
                obstacle.enabled = true;
                agent.enabled = false;
            }
            else
            {
                // If we are not in range, become an agent again
                obstacle.enabled = false;
                agent.enabled = true;

                agent.destination = samurai.transform.position;
                Debug.Log(samurai.transform.position);
                ghoul.GetComponent<Animator>().SetBool("attack", false);
                ghoul.GetComponent<Animator>().SetFloat("speed", 5);
            }
            index++;
            /*
            Agent = i.GetComponent<NavMeshAgent>();
            if (Vector3.Distance(i.transform.position, _mUnit.transform.position) > 2)
                Agent.SetDestination(_mUnit.transform.position);
            else
                Agent.Stop();
            if (Agent.hasPath)
                Agent.acceleration = (Agent.remainingDistance < closeEnoughMeters) ? deceleration : acceleration;
 
     
            Debug.Log(Vector3.Distance(i.transform.position, _mUnit.transform.position).ToString());
            if (Vector3.Distance(i.transform.position, _mUnit.transform.position) < 2)
            {
                // attack
                i.GetComponent<Animator>().SetBool("attack", true);
                i.GetComponent<Animator>().SetFloat("speed", 0);
                _mUnit.GetComponent<test>().hp--;
            }
             */
        }

    }
    void Attack(double time, GameObject samurai, GameObject ghoul)
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            samurai.GetComponent<CharacterStats>().SufferDamage(ghoul.GetComponent<CharacterStats>().attackDamage);
            time = 0.9;
        }
    }
}
