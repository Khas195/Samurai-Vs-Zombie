using UnityEngine;
using System.Collections;

namespace Game.Core.Singleton
{
    public class Singleton 
    {
        protected static Singleton instance;

        /**
           Returns the instance of this singleton.
        */
        protected static Singleton Instance<T>(T instance) where T : Singleton, new()
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}