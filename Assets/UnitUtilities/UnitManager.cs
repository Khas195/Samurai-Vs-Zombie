using UnityEngine;
using System.Collections;
using Assets.UnitUtilities;

public class UnitManager {

	private static UnitManager instance = new UnitManager();

    private UnitManager() { }
    public static UnitManager getInstance()
    {
        return instance;
    }

    ArrayList mUnits = new ArrayList();
    void Start()
    {
        GameObject temp;
        for (int i = 0; i < 100; i++)
        {
            temp = GameObject.Find("Knight " + i);

        }
    }
    public void Initialize(string type)
    { 
        GameObject temp;
        for (int i = 0; i < 100; i++)
        {
            temp = GameObject.Find(type + i);
            mUnits.Add(temp);
        }
    }
 }
