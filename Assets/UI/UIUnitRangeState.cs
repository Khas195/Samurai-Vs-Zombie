using UnityEngine;
using System.Collections;
using Game.Core.MessageModule;

namespace Game.Core.UI
{
    public class UIUnitRangeState : UIState
    {
        static UIUnitRangeState instance;
        public static UIUnitRangeState GetInstance()
        {
            if (instance == null)
            {
                instance = new UIUnitRangeState();
            }
            return instance;
        }

        UIManager mManager; // cache for manager
        Command unitCommand;
        Material color;
        GameObject target;
        bool firstClick;
        public void Init(UIManager mManager)
        {
            target = new GameObject();
            this.mManager = mManager;
        }
        public void SetCommand(Command command, Material color)
        {
            this.unitCommand = command;
            this.color = color;
        }
        public void OnGUI()
        {
        }

        public void OnTouch(RaycastHit hit)
        {
            if (firstClick == true)
            {
                firstClick = false;
                return;
            }
            if (hit.transform.gameObject == mManager.unitRange)
            {
                cData info = cData.CreatePackage();
                info.SetValue<GameObject>("SELF", UISelecting.GetInstance().GetSelectingUnit());
                if ( hit.transform.gameObject.GetComponent<Unit>() != null)
                {
                    info.SetValue<GameObject>("TARGET", hit.transform.gameObject);
                }
                else
                {
                    this.target.transform.position = hit.point;
                    info.SetValue<GameObject>("TARGET", this.target);
                }
                UISelecting.GetInstance().GetSelectingUnit().GetComponent<Unit>().setCommand(this.unitCommand);
                cData.ReturnPackage(info);
            }
            else if (hit.transform.gameObject.GetComponent<Unit>() != null)
            {
                UISelecting.GetInstance().SetSelectingUnit(hit.transform.gameObject);
                mManager.PopUntil(UISelecting.GetInstance());
                return;
            } 
            mManager.PopUntil(UIIdle.GetInstance());
        }

        public void OnPressed()
        {
        }

        public void OnPushed()
        {
            firstClick = true;
            Unit mUnit = UISelecting.GetInstance().GetSelectingUnit().GetComponent<Unit>();
            mManager.unitRange.GetComponent<MeshRenderer>().material = this.color;
            mManager.unitRange.transform.position = new Vector3(mUnit.transform.position.x, 0, mUnit.transform.position.z);
            mManager.unitRange.SetActive(true);
            mManager.unitRange.transform.localScale = new Vector3(mUnit.attackRange, 0.01f, mUnit.attackRange);
        }

        public void OnPoped()
        {
            mManager.unitRange.SetActive(false);
            this.mManager = null;
            this.color = null;
            this.unitCommand = null;
        }

        public void OnReturnTop()
        {
        }
    }
}
