using UnityEngine;
using System.Collections;

public class MoveInitialize {
    public GameObject circle = new GameObject();
    private static MoveInitialize instance = new MoveInitialize();

    private MoveInitialize() { }
    public static MoveInitialize getInstance()
    {
        return instance;
    }
    void Awake(){
        circle = GameObject.Find("Cylinder");
        circle.SetActive(false);
    }
    public GameObject getCircle()
    {
        if (circle == null)
            circle = GameObject.Find("Cylinder");
        return circle;
    }
}
