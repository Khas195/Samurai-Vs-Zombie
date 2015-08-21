using UnityEngine;
using System.Collections;
using Game.Core.StateStackPackage;
namespace Game.Engine.Menu
{

    public class CreditsMenu : IMenu
    {
        Menu menu;
        private static CreditsMenu instance = new CreditsMenu();

        private CreditsMenu() { }
        public static CreditsMenu getInstance()
        {
            return instance;
        }

        // Use this for initialization
        void Start()
        {

        }
        public void setMenu(Menu _menu)
        {
            menu = _menu;
        }
        // Update is called once per frame
        void Update()
        {

        }

        public void OnPressed()
        {
        }

        public void OnPushed()
        {
        }

        public void OnPoped()
        {
        }

        public void OnReturnTop()
        {
        }

        public void Initialize()
        {

        }

        public void buttonSetup(UnityEngine.UI.Button button)
        {
        }

        public void handleButton(UnityEngine.UI.Button button)
        {
        }
    }
}
