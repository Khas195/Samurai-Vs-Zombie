using UnityEngine;
using System.Collections.Generic;
using System.Collections;
namespace Game.Core.ObjectPool
{
    public class GameObjectPool
    {

        #region ObjectPooling
        // Storage and beingUsed for object pool
        Stack<GameObject> storage = new Stack<GameObject>();
        LinkedList<GameObject> beingUsed = new LinkedList<GameObject>();

        GameObject sample;

        public GameObjectPool(GameObject sample)
        {
            this.sample = sample;
        }
        // Create and return new game object if storage is empty
        public GameObject RequestGameObject()
        {
            GameObject newObject;
            // if Storage is empty create new Game Objectmonokai
            if (storage.Count <= 0)
                newObject = MonoBehaviour.Instantiate(sample);
            else
            {
                // else get from storage
                newObject = storage.Pop();
            }
            // add that Game Object to beingUsed List
            beingUsed.AddLast(newObject);
            newObject.SetActive(true);
            return newObject;
        }

        // Return Game Object uppon finished using
        public void ReturnStorage(GameObject returnedGameObject)
        {
            returnedGameObject.SetActive(false);
            // check if the given game object is in beingUsed or not
            if (beingUsed.Contains(returnedGameObject))
            {
                beingUsed.Remove(returnedGameObject);
            }
            // push the Game Object into the storage
            storage.Push(returnedGameObject);
        }
        public LinkedList<GameObject> ReturnUsingList()
        {
            return beingUsed;
        }
        #endregion
    }
}