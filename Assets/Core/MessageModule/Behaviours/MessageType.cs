using UnityEngine;
using System.Collections;
using Game.Core.IGeneralBehaviours;
using Game.Core.Singleton;
namespace Game.Core.MessageModule.PortStrategy
{
    // Port's strategy pattern for either calling received message or returning collected data
    public interface MessageType 
    {
        void Send(Communicable component,cData package);
    }

    public class SendMessage : MessageType
    {

        public void Send(Communicable component, cData package)
        {
            component.Received(package);
        }

        public void PrintSelf()
        {
            Debug.Log("Send Message");
        }
    }

    public class CollectData :  MessageType
    {
        public void Send(Communicable component, cData package)
        {
            package = component.ReturnRequest(package);
        }

        public void PrintSelf()
        {
            Debug.Log("CollectData Message");
        }
    }

}