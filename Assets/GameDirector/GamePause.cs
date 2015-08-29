using UnityEngine;
using System.Collections;
using Game.Core.StateStackPackage;
public class GamePause : State {

    static GamePause instance;
    public static GamePause GetInstances()
    {
        if (instance == null)
            instance = new GamePause();
        return instance;
    }

    GameDirector mDirector;
    public void Init(GameDirector mDirector)
    {
        this.mDirector = mDirector;
    }

    public void OnPressed()
    {
    }

    public void OnPushed()
    {
        mDirector.inGameUI.gameObject.SetActive(false);
        mDirector.inGameMenu.gameObject.SetActive(true);
    }

    public void OnPoped()
    {
        mDirector.inGameUI.gameObject.SetActive(true);
        mDirector.inGameMenu.gameObject.SetActive(false);
    }

    public void OnReturnTop()
    {
    }
}
