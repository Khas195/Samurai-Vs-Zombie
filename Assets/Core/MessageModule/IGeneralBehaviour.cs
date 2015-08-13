using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
namespace Game.Core.IGeneralBehaviours
{   
    //last update 5/6/2015 - Ly Trung Chanh, Cao Thanh Tung
    //Description: the root of the strategy
    public interface IGeneralBehaviour
    {

        void PrintSelf();
        void ExecuteBehaviour(cData package);
    }

    //last update 5/6/2015 - Ly Trung Chanh, Cao Thanh Tung
    //Description: Null pattern class
    public class NullStrategy : IGeneralBehaviour
    {
        public void PrintSelf()
        {
            Debug.Log("Null Strategy");
        }


        public void ExecuteBehaviour(cData package)
        {
            Debug.Log("Execute Null");
        }
    }
}
