using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    private static ButtonManager instance = new ButtonManager();
    
    private ButtonManager() { }
    public static ButtonManager getInstance()
    {
        return instance;
    }

    public Button startGameButton;
    public Button optionButton;
    public Button creditsButton;
    public Button enableSoundButton;
    public string fuckyou;

    public string getFuckYou() { return fuckyou; }
    void Awake()
    {
        Debug.Log(startGameButton.name);
        Debug.Log("awake");
    }
    
    void Update()
    {
        Debug.Log(startGameButton.name);
    }
    public Button getStartGameButton(){
        
        return startGameButton;
    }

    public Button getOptionButton(){
        return optionButton;
    }

    public Button getCreditsButton(){
        return creditsButton;
    }

    public Button getEnableSoundButton(){
        return enableSoundButton;
    }
}
