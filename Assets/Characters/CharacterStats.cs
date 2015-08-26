using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {

    public float maxHealth;
    float curHealth;
    public float attackDamage;

    public float attackSpeed;
    public delegate void OnHealthChange(float health);
    public OnHealthChange onHealthReduced;
	// Use this for initialization
	void Start () {
        curHealth = maxHealth;
        
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void SufferDamage(float damage)
    {
        curHealth -= damage;
        if (onHealthReduced != null)
            onHealthReduced(curHealth);

    }
    public void Die()
    {
        // Heroes's Death
        Debug.Log("Heroes's Death");
    }
}
