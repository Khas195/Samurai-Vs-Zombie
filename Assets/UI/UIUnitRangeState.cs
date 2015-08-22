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
        float range;
        Material color;
        bool firstClick;
        public void Init(UIManager mManager)
        {
           
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
            if (hit.transform.gameObject == mManager.unitRange || hit.transform.gameObject.GetComponent<Unit>() != null)
            {
                GameObject selectedUnit = UISelecting.GetInstance().GetSelectingUnit();
                cData info = cData.CreatePackage();
                info.SetValue<GameObject>("SELF", selectedUnit);
                if (hit.transform.gameObject.GetComponent<Unit>() != null )
                {
                    Debug.Log("Command Attack passed");
                    info.SetValue<GameObject>("TARGET", hit.transform.gameObject);
                }
                else
                {
                    Debug.Log("Command Move passed");
                    this.mManager.moveTest.transform.position = hit.point;
                    info.SetValue<GameObject>("TARGET", this.mManager.moveTest);
                    
                }
                this.unitCommand.setCommandInfo(info);
                UISelecting.GetInstance().GetSelectingUnit().GetComponent<Unit>().SetCommand(this.unitCommand);
                
            }
            mManager.PopUntil(UIIdle.GetInstance());
        }

        private bool CheckWithinRange(Vector3 midPoint,Vector3 point)
        {
            float distance = Mathf.Sqrt(Mathf.Pow(midPoint.x - point.x, 2) + Mathf.Pow(midPoint.z - point.z, 2));
            if (range >= distance)
                return true;
            return false;
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
