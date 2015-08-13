using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private Touch touch;

    private void Update()
    {
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
            //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        // 0 for left click, 1 for right click, 2 for middle click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                MyGameObject mGameObject = hit.transform.gameObject.GetComponent<MyGameObject>();
                if (mGameObject != null)
                    mGameObject.onSelect();
                return;
                
            }
            UIManager.getInstance().reset();
        }
        //}
    }
}
