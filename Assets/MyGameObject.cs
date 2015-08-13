using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;
public class MyGameObject : MonoBehaviour {

    cData info;
    void Start()
    {
        info = cData.CreatePackage();
        info.SetValue<int>("Health", 100);
        info.SetValue<int>("Damage", 100);
    }
    public void onSelect()
    {

        UIManager.getInstance().receiveInfo(info);
    }
}
