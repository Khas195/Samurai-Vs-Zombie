using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// last update 4/6/2015 Cao Thanh Tung
namespace Game.Core.MessageModule
{
    // Description: This class is the object that will be use as parameter for all function
    // use in communicable class, port class 
    class PackageDef
    {
        public static readonly string RESULT_PACKAGE = " RESULTPACKAGE";
    }
    public class cData
    {
        Dictionary<string, object> data;
        List<string> keys = new List<string>();
        // Object pooling for Package
        #region ObjectPooling
        // Storage and beingUsed for object pool
        static Stack<cData> storage = new Stack<cData>();
        static LinkedList<cData> beingUsed = new LinkedList<cData>();

        // create new package as requested
        cData() 
        {
            data = new Dictionary<string, object>();
        }
        
        // Create and return new package if storage is empty
        public static cData CreatePackage()
        {
            cData myPackage;
            // if Storage is empty create new package
            if (storage.Count <= 0)
                myPackage = new cData();
            else
            {
                // else get from storage
                myPackage = storage.Pop();
            }
            // add that package to beingUsed List
            beingUsed.AddLast(myPackage);
            return myPackage;
        }
        
        // Return package uppon finished using
        public static void ReturnPackage(cData returnedPackage)
        {
            // clear the package of all information
            returnedPackage.ClearPackage();
            // check if the given package is in beingUsed or not
            if (beingUsed.Contains(returnedPackage))
            {
                beingUsed.Remove(returnedPackage);
            }
            // push the package into the storage
            storage.Push(returnedPackage);
        }
        void ClearPackage()
        {
            this.data.Clear();
        }
        #endregion

        #region Package's Method
        // cao thanh tung 4/6/2015
        public void SetValue<T>(string key, T value)
        {
            // Check if the package already contains that key
            if (data.ContainsKey(key))
            {
                data[key] = value;
                return;
            }

            // Add the key and value to the package  
            data.Add(key, value);
            keys.Add(key);            
        }

        public void SetValue<T>(string key,ref T value)
        {
            // Check if the package already contains that key
            if (data.ContainsKey(key))
            {
                data[key] = value;
                return;
            }

            // Add the key and value to the package  
            data.Add(key, value);
        }

        //ly trung chanh  4/6/2015, cao thanh tung 4/6/2015
        public T GetValue<T>(string key)
        {
            // Check if package does does not contain that key
            if (!data.ContainsKey(key))
                // default(T) means that it will return null for class, 0 for int, '\0' for string
                return default(T);

            //get the value in the key
            return (T)data[key];
            
        }
        // new code
        public List<string> GetAllKey()
        {
            return keys;
        }
        public Dictionary<string, object> GetData()
        {
            return data;
        }
        public void AddAllValueFromAnotherPackage(cData _data)
        {
            foreach (string k in _data.GetAllKey())
            {
                // Check if the package already contains that key
                if (data.ContainsKey(k))
                {
                    data[k] = _data.GetData()[k];
                }
                else
                // Add the key and value to the package  
                    data.Add(k, _data.GetData()[k]);
            }
        }
        #endregion
    }
}