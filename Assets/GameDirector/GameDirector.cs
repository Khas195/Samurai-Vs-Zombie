using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Game.Core.StateStackPackage;
public class GameDirector : MonoBehaviour {
    StateStack mStates;
    public ScreenLoader menuLoader;
    public Canvas inGameMenu;
    public Canvas inGameUI;
    public Canvas inGameOptions;
    public AudioSource musics;

    public CharacterStats player;
    public Animator gameOverAnim;

    bool soundsOn;
    public delegate void OnAudioToggle(bool mute);
    public OnAudioToggle OnSoundToggle;
	// Use this for initializatio
	void Awake () {
        mStates = new StateStack();
        inGameMenu.gameObject.SetActive(false);
        GamePause.GetInstances().Init(this);
        InGame.GetInstances().Init(this);
        mStates.Push(InGame.GetInstances());
        AudioListener.pause = false;
        player.onHealthReduced += this.TrackPlayerHealth;
        musics.loop = true;
        soundsOn = true;
	}
	
    public void BackToMenu()
    {
        
        while (mStates.Peek() != null)
            mStates.Pop();
    }
    public void PauseGame()
    {
        mStates.Push(GamePause.GetInstances());
    }
    public void RestartGame()
    {
        Debug.Log("RestartGame");
        this.menuLoader.sceneName = "PlayScene";
        this.menuLoader.LoadScene();
    }
    public void ResumeGame()
    {
        Debug.Log("Start resuming");
        while (mStates.Peek() != InGame.GetInstances())
        {
            Debug.Log("Pop");
            mStates.Pop();
        }
    }
    public void Options()
    {

    }
    public void ToggleSounds()
    {
        if (OnSoundToggle != null)
            OnSoundToggle(!soundsOn);
    }
    public void TrackPlayerHealth(float health)
    {
        if (health <= 0)
        {
            inGameUI.gameObject.SetActive(false);
            gameOverAnim.SetTrigger("GameOver");
        }
    }
}
