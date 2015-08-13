using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
using Game.Core.MessageModule.PortStrategy;
public class TestSendMessage : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        cData package = cData.CreatePackage();
       Debug.Log("Send Globally");
       this.GetComponentInParent<Port>().SendMessage(package,DefinitionForPort.CHILDREN, SendMessageDef.SEND_MESSAGE);
       this.GetComponentInParent<Port>().SendMessage(package, DefinitionForPort.CHILDREN, SendMessageDef.COLLECT_DATA);
       Debug.Log(package.GetValue<int>("Number"));

       Debug.Log("Send Locally");
       this.GetComponentInParent<Port>().SendMessage(package, DefinitionForPort.LOCAL, SendMessageDef.SEND_MESSAGE);
       this.GetComponentInParent<Port>().SendMessage(package, DefinitionForPort.LOCAL, SendMessageDef.COLLECT_DATA);
       Debug.Log(package.GetValue<int>("Number"));

       cData.ReturnPackage(package);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
