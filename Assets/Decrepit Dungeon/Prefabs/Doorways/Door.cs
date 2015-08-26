using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    bool isOpen = false;
	// Use this for initialization
	void Start () {
        isOpen = true;
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
