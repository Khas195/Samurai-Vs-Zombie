using UnityEngine;
using System.Collections;

public class UnitManager {

	private static UnitManager instance = new UnitManager();

    private UnitManager() { }
    public static UnitManager getInstance()
    {
        return instance;
    }

    bool unitIsSelected = false;
    GameObject selectedUnit = null;
    public bool getUnitIsSelected(){
        return unitIsSelected;
    }
    public void setUnitIsSelected(bool isSelected)
    {
        unitIsSelected = isSelected;
    }
    public GameObject getSelectedUnit()
    {
        return selectedUnit;
    }
    public void setSelectedUnit(GameObject _selectedUnit)
    {
        selectedUnit = _selectedUnit;
    }
 }
