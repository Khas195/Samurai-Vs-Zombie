using UnityEngine;
using System.Collections;
using Game.Core.StateStackPackage;
namespace Game.Core.UI
{
    public interface UIState :  State
    {
        void Init(UIManager mManager);
        void OnGUI();
        void OnTouch(RaycastHit hit);
    }
}
