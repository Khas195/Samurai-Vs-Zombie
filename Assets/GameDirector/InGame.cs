using UnityEngine;
using System.Collections;
using Game.Core.StateStackPackage;
using Game.Engine.Menu;
public class InGame : State {
    static InGame instance;
    public static InGame GetInstances()
    {
        if (instance == null)
            instance = new InGame();
        return instance;
    }

    GameDirector mDirector;
    public void Init(GameDirector mDirector)
    {
        this.mDirector = mDirector;
    }
    public void OnPressed()
    {
        Time.timeScale = 0;
    }

    public void OnPushed()
    {
        Time.timeScale = 1;
    }

    public void OnPoped()
    {
        mDirector.menuLoader.LoadScene();
    }

    public void OnReturnTop()
    {
        Time.timeScale = 1;
    }

}
