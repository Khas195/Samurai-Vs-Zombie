using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour{
    public GameObject mUnit;
    public GameObject gate;
    int area = 1;
    bool stop = false;
    public ArrayList ghouls = new ArrayList();
    NavMeshAgent agent;
    NavMeshObstacle obstacle;
    // Use this for initialization
    void Start()
    {
        Initialize();
        gate = GameObject.Find("Door 1");

        
    }
	
	// Update is called once per frame
    void Update()
    {
            Chase(ghouls, mUnit);
    }

    void Initialize()
    {
        for (int i = 1; i < 100; i++)
        {
            GameObject temp = GameObject.Find("ghoul " + i);
            if (temp)
                ghouls.Add(temp);
            else
                break;
        }
        foreach (GameObject i in ghouls)
        {
            i.GetComponent<Animator>().SetFloat("speed", 5);
        }
    }
    void Chase(ArrayList enemy, GameObject _mUnit)
    {
        foreach (GameObject i in enemy)
        {
            agent = i.GetComponent<NavMeshAgent>();
            obstacle = i.GetComponent<NavMeshObstacle>();
            

            // Test if the distance between the agent and the player
            // is less than the attack range (or the stoppingDistance parameter)
            if (Vector3.Distance(i.transform.position, _mUnit.transform.position) < 1.3)
            {
                // If the agent is in attack range, become an obstacle and
                // disable the NavMeshAgent component
                if (agent.enabled == true)
                {
                    
                    i.GetComponent<Animator>().SetBool("attack", true);
                    i.GetComponent<Animator>().SetFloat("speed", 0);
                }
                if (i.GetComponent<Animator>().GetBool("attack") == true && i.GetComponent<Animator>().GetFloat("speed") == 0)
                {
                    i.GetComponent<test>().attackTime -= Time.deltaTime;
                    if (i.GetComponent<test>().attackTime < 0)
                    {
                        _mUnit.GetComponent<test>().hp--;
                        Debug.Log(_mUnit.GetComponent<test>().hp);
                        i.GetComponent<test>().attackTime = 0.9;
                    }
                }
                obstacle.enabled = true;
                agent.enabled = false;
            }
            else
            {
                // If we are not in range, become an agent again
                obstacle.enabled = false;
                agent.enabled = true;
                agent.destination = _mUnit.transform.position;
                Debug.Log(_mUnit.transform.position);
                i.GetComponent<Animator>().SetBool("attack", false);
                i.GetComponent<Animator>().SetFloat("speed", 5);
            }
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
}
