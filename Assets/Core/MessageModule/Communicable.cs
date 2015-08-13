using UnityEngine;
using System.Collections;

namespace Game.Core.MessageModule
{
    public interface Communicable
    {
        void Received(cData package);
        cData ReturnRequest(cData package);
    }
}
