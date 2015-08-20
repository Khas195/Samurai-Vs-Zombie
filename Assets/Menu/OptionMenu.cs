using UnityEngine;
using System.Collections;
using Game.Core.StateStack;
using UnityEngine.UI;
namespace Game.Engine.Menu
{
    public class OptionMenu : IMenu
    {
        Menu menu;

        private static OptionMenu instance = new OptionMenu();

        private OptionMenu() { }
        public static OptionMenu getInstance()
        {
            return instance;
        }

        public void setMenu(Menu _menu)
        {
            menu = _menu;
        }

        public void OnPressed()
        {
            menu.enableSoundButton.gameObject.SetActive(false);
        }

        public void OnPushed()
        {
            menu.enableSoundButton.gameObject.SetActive(true);
        }

        public void OnPoped()
        {
            menu.enableSoundButton.gameObject.SetActive(false);
        }

        public void OnReturnTop()
        {
            menu.enableSoundButton.gameObject.SetActive(true);
        }



        public void Initialize()
        {
            menu.enableSoundButton.gameObject.SetActive(false);
            buttonSetup(menu.enableSoundButton);
        }

        public void buttonSetup(Button button)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => handleButton(button));
        }

        public void handleButton(Button button)
        {
            
            if (button == menu.enableSoundButton)
            {
                if (AudioListener.volume == 0.0f)
                {
                    AudioListener.volume = 1.0f;
                }
                else
                    AudioListener.volume = 0.0f;
                Debug.Log(AudioListener.volume);
            }

        }
    }
}