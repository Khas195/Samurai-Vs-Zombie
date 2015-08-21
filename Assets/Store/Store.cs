using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {
    Resolution[] resolutions = Screen.resolutions;
    
    int numberOfUnit;
    public Button increaseUnitButton;
    public Button decreaseUnitButton;
    public Button backButton;
	// Use this for initialization
	void Start () {
        buttonSetup(increaseUnitButton);
        buttonSetup(decreaseUnitButton);

        
		// Print the resolutions
        print("width " + resolutions[0].width);
		// Switch to the lowest supported fullscreen resolution
		Screen.SetResolution (resolutions[0].width, resolutions[0].height, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void buttonSetup(Button button)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => handleButton(button));
    }

    public void handleButton(Button button)
    {
        if (button == increaseUnitButton)
            numberOfUnit++;
        else if (button == decreaseUnitButton)
            numberOfUnit--;
        //
        //else if (button == backButton)
        //      return numberOfUnit    
    }
}
