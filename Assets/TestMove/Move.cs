using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    //flag to check if the user has tapped / clicked. 
    //Set to true on click. Reset to false on reaching destination
    private bool flag = false;
    //destination point
    private Vector3 endPoint;
    //alter this to change the speed of the movement of player / gameobject
    public float duration = 50.0f;
    //vertical position of the gameobject
    private float yAxis;
    NavMeshAgent agent;

    
    GameObject Circle;
    void Start()
    {
        //save the y axis value of gameobject
        yAxis = gameObject.transform.position.y;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Circle = GameObject.Find("Cylinder");
        //Circle.SetActive(false);
        //check if the screen is touched / clicked   
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0))   )
        {

            
            //declare a variable of RaycastHit struct
            RaycastHit hit;

            //Create a Ray on the tapped / clicked position
            Ray ray;

            //for unity editor
#if UNITY_EDITOR
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //for touch device
#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
   ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
#endif
            //Check if the ray hits any collider
            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.collider.name == "Cylinder")
                {
                    //set a flag to indicate to move the gameobject
                    flag = true;
                    //save the click / tap position
                    endPoint = hit.point;
                    //as we do not want to change the y axis value based on touch position, reset it to original y axis value
                    endPoint.y = yAxis;
                    Debug.Log(endPoint);
                    
                   
                    
                }
                else if (hit.collider.name != "Plane")
                {
                    Circle.transform.position = hit.collider.transform.position;
                    Circle.SetActive(true);
                }
                else if (Circle != null)
                    Circle.SetActive(false);
                else if (hit.collider.name == "Plane")
                {
                    Circle.SetActive(false);
                }
            }

        }
        

    }
}