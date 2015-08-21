using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game.Core.StateStackPackage
{
    public class StateStack
    {
        private static StateStack instance = new StateStack();

        public static StateStack getInstance()
        {
            return instance;
        }

        Stack<State> mStates;
        public StateStack()
        {
            mStates = new Stack<State>();
        }
        public void Push(State state)
        {
            if (state == null)
            {
                Debug.Log("You are trying to push a null state into stack");
                return;
            }
            if (mStates.Count > 0)
            {

                mStates.Peek().OnPressed();
            }
            state.OnPushed();

            Debug.Log("A state is push");
            mStates.Push(state);
        }
        public State Pop()
        {
            Debug.Log("POP");
            if (mStates.Count > 0)
            {
                mStates.Peek().OnPoped();
                State temp = mStates.Pop();
                if (mStates.Count > 0)
                {
                    mStates.Peek().OnReturnTop();
                }
                return temp;
            }
            return null;
        }
        public State Peek()
        {
            if (mStates.Count > 0)
            {
                return mStates.Peek();
            }
            return null;
        }
    }
}