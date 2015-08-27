using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour
{
    public GameObject monsters;
    public GameObject samurai;
    bool isTriggered = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Cube")
        {
            if (isTriggered == false)
            {
                monsters.GetComponent<EnemyAI>().SetTarget(collider.gameObject);
                isTriggered = true;
            }
            else
            {
                monsters.GetComponent<EnemyAI>().ReturnToOriginalPosition();
                isTriggered = false;
            }
        }
    }
}
