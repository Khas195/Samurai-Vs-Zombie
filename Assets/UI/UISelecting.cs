using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using Game.Core.StateStackPackage;
using Game.Core.MessageModule;
namespace Game.Core.UI
{
    public class UISelecting :   UIState
    {
        static UISelecting instance;
        public static UISelecting GetInstance()
        {
            if (instance == null)
            {
                instance = new UISelecting();
            }
            return instance;
        }

        GameObject selectingUnit;

        UIManager mManager; // cache for manage
            
        public void OnPressed()
        {
        }
        public void OnPushed()
        {
        }

        public void OnPoped()
        {
            this.selectingUnit = null;
        }


        public void OnReturnTop()
        {
        }

        public void Init(UIManager uIManager)
        {
            this.mManager = uIManager;

        }
        public void OnTouch(RaycastHit hit)
        {
            if ( hit.transform.gameObject.GetComponent<Unit>() != null )
            {
                this.selectingUnit = hit.transform.gameObject;
            }
            else mManager.GetStateStack().Pop();
        }
        public void SetSelectingUnit(GameObject selected)
        {
            this.selectingUnit = selected;
        }
        public GameObject GetSelectingUnit()
        {
            return this.selectingUnit;
        }
        public void OnGUI()
        {
            float sizeX = mManager.buttonList[0].width * mManager.uiScaleX * mManager.buttonList.Count;
            float sizeY = mManager.uiPanel.height * mManager.uiScaleY;

            Vector3 pos = Camera.main.WorldToScreenPoint(this.selectingUnit.transform.position);

            float uiPannelPosX = pos.x - sizeX / 2;
            float uiPannelPosY = Screen.height - pos.y;

            GUIStyle container = new GUIStyle();
            container.normal.background = mManager.uiPanel;
            GUI.Box(new Rect(uiPannelPosX, uiPannelPosY, sizeX, sizeY), "", container);

            float offset = mManager.buttonList[0].width * mManager.uiScaleX;
            for (int i = 0; i < mManager.buttonList.Count; i++)
            {
                Texture2D temp = mManager.buttonList[i];
                GUIStyle icon = new GUIStyle();
                icon.normal.background = temp;

                if (GUI.Button(new Rect(uiPannelPosX + (offset * i), uiPannelPosY, temp.width * mManager.uiScaleX, temp.height * mManager.uiScaleY), "", icon))
                {
                    UIUnitRangeState.GetInstance().Init(mManager);

                    if (temp.name == "MoveButton")
                    {
                         
                        UIUnitRangeState.GetInstance().SetCommand(new MoveCommand(), mManager.moveRange);
                    }
                    else if (temp.name == "AttackButton")
                    {
                        UIUnitRangeState.GetInstance().SetCommand(new AttackCommand(), mManager.attRange);
                    }
                    else if (temp.name == "AbilitiesButton")
                    {
                        UIUnitRangeState.GetInstance().SetCommand(new AbilityCommand(), mManager.abilityRange);
                    }
                    else if (temp.name == "InfoButton")
                    {

                    }
                    mManager.GetStateStack().Push(UIUnitRangeState.GetInstance());
                }
            }
        }

    }
}
