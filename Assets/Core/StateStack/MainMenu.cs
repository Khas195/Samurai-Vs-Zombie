using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Game.Core.StateStack;

public class MainMenu : MonoBehaviour, State{


    Button startGameButton = ButtonManager.getInstance().getStartGameButton();
    Button optionButton = ButtonManager.getInstance().getOptionButton();
    Button creditsButton = ButtonManager.getInstance().getCreditsButton();

    StateStack stateStack = StateStack.getInstance();
    OptionMenu optionMenu = OptionMenu.getInstance();
    Credits credits = new Credits();

    public void OnPressed()
    {
        startGameButton.gameObject.SetActive(false);
        optionButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
    }

    public void OnPushed()
    {
        startGameButton.gameObject.SetActive(true);
        optionButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
    }

    public void OnPoped()
    {
        Object.Destroy(startGameButton);
        Object.Destroy(optionButton);
        Object.Destroy(creditsButton);
    }

    public void OnReturnTop()
    {
        startGameButton.gameObject.SetActive(true);
        optionButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
    }


    public void Start()
    {
        Debug.Log(ButtonManager.getInstance().getFuckYou());
        stateStack.Push(this);

        buttonSetup(startGameButton);
        buttonSetup(optionButton);
        buttonSetup(creditsButton);
    }

    void buttonSetup(Button button)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => handleButton(button));
    }

    void handleButton(Button button)
    {
        if (button = optionButton)
        {
            stateStack.Push(optionMenu);
        }
        else if (button = creditsButton)
        {
            stateStack.Push(credits);
        }
    }
}
