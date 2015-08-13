using UnityEngine;
using System.Collections;

using Game.Core.MessageModule.PortStrategy;
namespace Game.Core.MessageModule
{
    //Last update: 4/6/2015 - Ly Trung Chanh
    //Description: list of commands for port
    public class DefinitionForPort
    {
        public static readonly string CHILDREN = "CHILDREN";
        public static readonly string LOCAL = "LOCAL";
    }

    //Last update: 4/6/2015 - Cao Thanh Tung
    //Description: list of commands for sending message
    public class SendMessageDef : MonoBehaviour
    {
        public static readonly SendMessage SEND_MESSAGE = new SendMessage();
       
        public static readonly CollectData COLLECT_DATA = new CollectData();
        
    }

    
}
