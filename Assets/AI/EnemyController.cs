using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyController : MonoBehaviour {
    Animator ghoulAnimator;
    CharacterStats ghoulStats;
    NavMeshAgent ghoulAgent;
    NavMeshObstacle ghoulObstacle;
    Vector3 ghoulOriginalPosition;
    AudioSource audio;
    void Awake()
    {
        ghoulAgent = this.GetComponent<NavMeshAgent>();
        ghoulAnimator = this.GetComponent<Animator>();
        ghoulStats = this.GetComponent<CharacterStats>();
        ghoulObstacle = this.GetComponent<NavMeshObstacle>();
        ghoulOriginalPosition = this.transform.position;
        audio = this.GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision other )
    {
        Debug.Log("trigger " + other.gameObject.tag);
        if (other.gameObject.tag == "samurai")
        {
            ghoulStats.SufferDamage(other.gameObject.GetComponent<CharacterStats>().attackDamage);
        }
    }
    public Animator GetGhoulAnimator()
    {
        return ghoulAnimator;
    }
    public CharacterStats GetGhoulStats()
    {
        return ghoulStats;
    }
    public NavMeshAgent GetGhoulAgent()
    {
        return ghoulAgent;
    }
    public NavMeshObstacle GetGhoulObstacle()
    {
        return ghoulObstacle;
    }
    public Vector3 GetGhoulOriginalPosition()
    {
        return ghoulOriginalPosition;
    }
    public AudioSource GetAudioSource()
    {
        return audio;
    }
}
