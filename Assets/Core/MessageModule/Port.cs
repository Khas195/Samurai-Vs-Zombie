using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Game.Core.MessageModule.PortStrategy;
using Game.Core.IGeneralBehaviours;
namespace Game.Core.MessageModule
{
    public class Port : MonoBehaviour
    {
        // Note for future: Make this not creatable for any class
        public bool isChecked { get; private set;}

        //last update 4/6/2015 - Ly Trung Chanh, Cao Thanh Tung
        void Awake()
        {           
            isChecked = false;
        }
     
        //last update 5/6/2015 - Ly Trung Chanh, Cao Thanh Tung
        //updated 4/6/2015 - Ly Trung Chanh, Cao Thanh Tung

        // <summary>
        //Descriptions: Send messages to all children and/or ancestors
        // </summary>
        public void SendMessage(cData package, string command, MessageType messageType)
        {

            // Start procedure to send message 
            // Check that this port is already been passed through
            isChecked = true;

            if (messageType == null)
                return;
            // Cache for  this.transform.GetChild(i).GetComponent<Communicable>()
            Communicable tempCommunicable; 

            // Send package to all of it's children
            for (int i = 0; i < this.transform.childCount; i++)
            {
                tempCommunicable = this.transform.GetChild(i).GetComponent<Communicable>();
                if (tempCommunicable != null)
                    messageType.Send(tempCommunicable, package);
            }
         // End procedure of sending message locally

        //--------------------------------------------------------------------------------------------------------
         
            //Start procedure to send message children
                // Send package to ancestors' ports to send the package to all ports
                if (command == DefinitionForPort.CHILDREN)
                {
                    // Cache for this.transform.GetChild(i).GetComponent<Port>()
                    Port port;

                    // Loop through all children to find the port ( if exist) and continue to send message
                    for (int i = 0; i < this.transform.childCount; i++)
                    {
                        port = this.transform.GetChild(i).GetComponent<Port>();
                        SendMessageToPort(package, command, messageType, port);
                    }
                }
                // End procedure to send message children

            isChecked = false;
        }


        //last update 5/6/2015 - Ly Trung Chanh - Cao Thanh Tung
        // extract sendmessage to port 
        private static void SendMessageToPort(cData package, string command, MessageType message, Port port)
        {
            if (port != null && port.isChecked == false)
                port.SendMessage(package, command, message);
        }

        // Clean Up Data
        void OnDestroy()
        {
            isChecked = false;
        }
    }
}