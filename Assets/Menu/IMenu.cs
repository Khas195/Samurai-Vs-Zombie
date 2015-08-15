using UnityEngine;
using System.Collections;
using Game.Core.StateStack;
using UnityEngine.UI;
namespace Game.Engine.Menu
{
    public interface IMenu : State
    {

        void Initialize();
        void buttonSetup(Button button);
        void handleButton(Button button);
        
    }
}