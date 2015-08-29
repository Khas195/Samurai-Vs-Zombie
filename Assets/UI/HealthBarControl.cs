using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarControl : MonoBehaviour {

    public CharacterStats mChar;
    public Text mTextPercentage;

    public GameObject visibleHealth; // cache for visibleHealth
    private Image healthBarImage;
    private float maxHealth; // cache max health
	// Use this for initialization
	void Start () {

        mChar.onHealthReduced += HandleHealthChange;
        healthBarImage = visibleHealth.GetComponent<Image>();
        maxHealth = mChar.maxHealth;

	}
	public void HandleHealthChange(float newHealth)
    {
        float healthPercentage = newHealth / maxHealth;
        mTextPercentage.text = healthPercentage*100 + "%";
        visibleHealth.transform.localScale = new Vector3(healthPercentage, 1, 1);
        if (healthPercentage >= .4 && healthPercentage <= .6 )
        {
            healthBarImage.color = new Color32(200, 255, 0, 255);// yellow-ish
        }
        else if ( healthPercentage < .4)
        {
            healthBarImage.color = new Color32(255, 0, 0, 255);// red
        }
        else
        {
            Debug.Log("Green Health");
            healthBarImage.color = new Color32(0, 255, 0, 255); // green
        }
        
    }
}
