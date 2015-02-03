using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class UnitManager : MonoBehaviour {

    private List<Unit> _selectedUnits = new List<Unit>();


    public void SelectSingleUnit(Unit unit)
    {
        DeselectAllUnits();
        unit.IsSelected = true;
        unit.SelectionIndicator.SetActive(true);
        _selectedUnits.Add(unit);
    }

    public void SelectAditionalUnit(Unit unit)
    {
        unit.IsSelected = true;
        unit.SelectionIndicator.SetActive(true);
        _selectedUnits.Add(unit);
    }

    public void SelectMultipleUnits(List<Unit> units)
    {
        DeselectAllUnits();

        foreach (var unit in units)
        {
            unit.IsSelected = true;
            unit.SelectionIndicator.SetActive(true);
            _selectedUnits.Add(unit);
        }

    }

    public void DeselectSingleUnit(Unit unit)
    {
        if (_selectedUnits.Contains(unit))
        {
            unit.IsSelected = false;
            unit.SelectionIndicator.SetActive(false);
            _selectedUnits.Remove(unit);
        }
    }

    public void DeselectAllUnits()
    {
        foreach (var unit in _selectedUnits)
        {
            unit.IsSelected = false;
            unit.SelectionIndicator.SetActive(false);
        }
        _selectedUnits.Clear();
    }

    public List<Unit> GetSelectedUnits()
    {
        return _selectedUnits;
    }
}
