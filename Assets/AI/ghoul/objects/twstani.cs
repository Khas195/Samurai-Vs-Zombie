using UnityEngine;
using System.Collections;

public class twstani : MonoBehaviour {
   public Animator m_Animator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            m_Animator.SetBool("run", true);
        if (Input.GetKeyUp(KeyCode.Space))
            m_Animator.SetBool("run", false);
	}
}
