using UnityEngine;
using System.Collections;
using Game.Core.StateStack;
using UnityEngine.UI;
public class OptionMenu : State
{
    private static OptionMenu instance = new OptionMenu();
    Button enableSoundButton = ButtonManager.getInstance().getEnableSoundButton();
    
    private OptionMenu() { }
    public static OptionMenu getInstance(){
        return instance;
    }
    
    public void OnPressed()
    {
        enableSoundButton.gameObject.SetActive(false);
    }

    public void OnPushed()
    {
        enableSoundButton.gameObject.SetActive(true);
    }

    public void OnPoped()
    {
        Object.Destroy(enableSoundButton);
    }

    public void OnReturnTop()
    {
        enableSoundButton.gameObject.SetActive(true);
    }

    void Start()
    {
        enableSoundButton.gameObject.SetActive(false);
        buttonSetup(enableSoundButton);
    }

    void buttonSetup(Button button)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => handleButton(button));
    }

    void handleButton(Button button)
    {
        if (button = enableSoundButton)
        {
            if (AudioListener.volume == 0.0f)
            {
                AudioListener.volume = 1.0f;
            }
            else
                AudioListener.volume = 0.0f;
        }
        
    }
}
