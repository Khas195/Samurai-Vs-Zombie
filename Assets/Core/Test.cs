using UnityEngine;
using System.Collections;

using Game.Core.MessageModule;

public class Test : MonoBehaviour, Communicable {


	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Received(cData package)
    {
        Debug.Log(this.gameObject.name + "Receive Message");
    }

    public cData ReturnRequest(cData package)
    {
        Debug.Log(this.gameObject.name + "Return Request");
        int i = 0;
        if (package.GetValue<int>("Number") != 0)
            i = package.GetValue<int>("Number");

        i++;
        package.SetValue<int>("Number", i);
        return package;
    }
}
