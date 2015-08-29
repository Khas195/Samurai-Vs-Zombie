using UnityEngine;
using System.Collections;

public class SamuraiSounds : MonoBehaviour {

    public Animator mAnimator;

    public AudioSource stabs;
    public AudioSource slash;
    public AudioSource slashHit;
    public AudioSource stabsHit;
	// Use this for initialization
    public void StabSounds()
    {
        if (!stabs.isPlaying)
        {
            stabs.Play();
        }
    }
    public void SlashSounds()
    {
        if (!slash.isPlaying)
        {
            slash.Play();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ghoul")
        {
            if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                stabsHit.Play();
                slashHit.Play();
            }
        }
    }
    public void MuteSounds(bool mute)
    {
        stabs.mute = mute;
        slash.mute = mute;
        slashHit.mute = mute;
        stabsHit.mute = mute;
    }
}
