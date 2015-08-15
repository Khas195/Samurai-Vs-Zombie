using UnityEngine;
using System.Collections;

public class UnitSelection : MonoBehaviour
{
    bool moved = false;
    NavMeshAgent agent;
    NavMeshAgent selectedAgent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.name == agent.name)
                {
                    selectedAgent = agent;
                    //circle.SetActive(true);
                    //circle.transform.position = new Vector3(hit.collider.transform.position.x, (float)-0.1, hit.collider.transform.position.z);
                }
                else if (selectedAgent != null)
                {
                    selectedAgent.SetDestination(hit.point);
                    selectedAgent = null;
                }
            }
        }
    }
}