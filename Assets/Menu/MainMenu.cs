using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Game.Core.StateStack;
namespace Game.Engine.Menu
{
    public class MainMenu : IMenu
    {

        Menu menu;

        private static MainMenu instance = new MainMenu();

        private MainMenu() { }
        public static MainMenu getInstance()
        {
            return instance;
        }

        public void setMenu(Menu _menu)
        {
            menu = _menu;
        }

        void setButtonActive(bool isActive)
        {
            menu.startGameButton.gameObject.SetActive(isActive);
            menu.optionButton.gameObject.SetActive(isActive);
            menu.creditsButton.gameObject.SetActive(isActive);
        }

        public void OnPressed()
        {
            setButtonActive(false);
        }

        public void OnPushed()
        {
            setButtonActive(true);
        }

        public void OnPoped()
        {
            setButtonActive(false);
        }

        public void OnReturnTop()
        {
            setButtonActive(true);
        }




        public void Initialize()
        {
            buttonSetup(menu.startGameButton);
            buttonSetup(menu.optionButton);
            buttonSetup(menu.creditsButton);
        }

        public void buttonSetup(Button button)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => handleButton(button));
        }

        public void handleButton(Button button)
        {
            if (button == menu.optionButton)
            {
                menu.getStateStack().Push(OptionMenu.getInstance());
            }
            else if (button == menu.creditsButton)
            {
                menu.getStateStack().Push(CreditsMenu.getInstance());
            }
        }
    }
}