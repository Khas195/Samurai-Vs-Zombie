using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Core.StateStackPackage;
namespace Game.Core.UI
{
    public class UIManager : MonoBehaviour
    {
        Camera camera;
        StateStack uiStates;

        public float uiScaleX;
        public float uiScaleY;

        public GameObject unitRange;
        public Material attRange;
        public Material moveRange;
        public Material abilityRange;

        public List<Texture2D> buttonList;
        public Texture2D uiPanel;

        // Use this for initialization
        void Start()
        {
            camera = this.GetComponent<Camera>();
            unitRange.SetActive(false);
            uiStates = new StateStack();
            UISelecting.GetInstance().Init(this);
            UIIdle.GetInstance().Init(this);
            uiStates.Push(UIIdle.GetInstance());
        }

        // Update is called once per frame
        void Update()
        {
            Touches();
        }
        void OnGUI()
        {
            if ( uiStates.Peek() != null)
                (uiStates.Peek() as UIState).OnGUI();

        }
        public void Touches()
        {
            // 0 -> left mouse
            if (Input.GetMouseButtonUp(0))
            {
                //this.enabled = !this.enabled;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    try
                    {
                        if (uiStates.Peek() != null)
                            (uiStates.Peek() as UIState).OnTouch(hit);

                    }
                    catch (InvalidCastException)
                    {
                        Debug.Log("Casting fail at UIManager, Touches() function");
                    }
                }
            }
        }


        public StateStack GetStateStack()
        {   
            return uiStates;
        }

        public Camera GetCamera()
        {
            return camera;
        }

        public void PopUntil(State state)
        {
            while (this.uiStates.Peek() != state )
            {
                uiStates.Pop();
            }
        }
    }
}
