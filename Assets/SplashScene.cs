using UnityEngine;
using System.Collections;

public class SplashScene : MonoBehaviour {
    public ScreenLoader screenLoader;
	// Use this for initialization
	void Start () {
        Debug.Log("Load Scene");
        screenLoader.LoadScene();
	}
}
