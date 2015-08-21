using UnityEngine;
using System.Collections;
using Game.Core.StateStackPackage;
namespace Game.Core.UI
{
    public class UIIdle : UIState
    {
        static UIIdle instance;
        public static UIIdle GetInstance()
        {
            if ( instance == null)
            {
                instance = new UIIdle();
            }
            return instance;
        }
        UIManager mManager;
        public void Init(UIManager mManager)
        {
            this.mManager = mManager;
        }
        public void OnPressed()
        {
        }

        public void OnPushed()
        {
        }

        public void OnPoped()
        {
        }

        public void OnReturnTop()
        {
        }

        public void OnTouch(RaycastHit hit)
        {
            GameObject gameObject = hit.transform.gameObject;
            Debug.Log(hit.transform.position);
            if ( gameObject.GetComponent<Unit>() == null)
            {
                Debug.Log("Object does not have Unit script in it");
                return;
            }
            UISelecting.GetInstance().SetSelectingUnit(gameObject);
            mManager.GetStateStack().Push(UISelecting.GetInstance());
        }


        public void OnGUI()
        {
        }
    }
}
