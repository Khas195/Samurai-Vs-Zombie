using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public class UIManager  {
    static UIManager instance;
    public static UIManager getInstance()
    {
        if (instance == null)
        {
            instance = new UIManager();
        }
        return instance;
    }
    public void receiveInfo(cData info)
    {
        Debug.Log("Health: " + info.GetValue<int>("Health") + " Damage: " + info.GetValue<int>("Damage"));
    }
    public void reset()
    {
        Debug.Log("Reset");
    }
}
