using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {

    public float maxHealth;
    float curHealth;
    public float attackDamage;

    public delegate void OnHealthChange(float health);
    public OnHealthChange onHealthReduced;

	// Use this for initialization
	void Start () {
        curHealth = maxHealth;
        
	}
	

    public void SufferDamage(float damage)
    {
        curHealth -= damage;
        if (onHealthReduced != null)
            onHealthReduced(curHealth);

    }
    public float getCurHealth()
    {
        return curHealth;
    }


}
