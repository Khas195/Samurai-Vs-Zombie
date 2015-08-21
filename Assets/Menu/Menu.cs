using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Game.Core.StateStackPackage;
namespace Game.Engine.Menu
{
    public class Menu : MonoBehaviour
    {

        public Button startGameButton;
        public Button optionButton;
        public Button creditsButton;
        public Button enableSoundButton;
        public Button backButton;

        StateStack stateStack = new StateStack();
        public StateStack getStateStack()
        {
            return stateStack;
        }

        // Use this for initialization
        void Start()
        {
            buttonSetup(backButton);
            MainMenu.getInstance().setMenu(this);
            CreditsMenu.getInstance().setMenu(this);
            OptionMenu.getInstance().setMenu(this);
            MainMenu.getInstance().Initialize();
            OptionMenu.getInstance().Initialize();
            CreditsMenu.getInstance().Initialize();
            stateStack.Push(MainMenu.getInstance());
        }

        // Update is called once per frame
        void Update()
        {

        }

        
        public void buttonSetup(Button button)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => handleButton(button));
        }

        public void handleButton(Button button)
        {

            if (button == backButton)
            {
                Debug.Log("back button clicked");
                stateStack.Pop();
            }

        }
    }
}