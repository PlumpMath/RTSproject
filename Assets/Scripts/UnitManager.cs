using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class UnitManager : MonoBehaviour 
{

    //private List<Unit> _selectedUnits = new List<Unit>();
    //private Dictionary<int, Unit> _UnitsByObjectId = new Dictionary<int, Unit>();
    private List<Unit> _selectedUnits = new List<Unit>();
    private Dictionary<int, Unit> _UnitsByObjectId = new Dictionary<int, Unit>();

    public void RegisterUnit(int id, Unit unit)
    {
        _UnitsByObjectId.Add(id, unit);
    }

    public void UnRegisterUnit(int id)
    {
        _UnitsByObjectId.Remove(id);
    }

    public Unit GetUnitByObjectId(int id)
    {
        Unit unit = null;

        _UnitsByObjectId.TryGetValue(id, out unit);

        return unit;
    }


    public void SelectSingleUnit(Unit unit)
    {
        DeselectAllUnits();
        ApplySelectionValues(true, unit);
        _selectedUnits.Add(unit);
    }

    public void SelectAditionalUnit(Unit unit)
    {
        ApplySelectionValues(true, unit);
        _selectedUnits.Add(unit);
    }

    public void SelectMultipleUnits(List<Unit> units)
    {
        DeselectAllUnits();

        foreach (var unit in units)
        {
            ApplySelectionValues(true, unit);
            _selectedUnits.Add(unit);
        }

    }

    public void DeselectSingleUnit(Unit unit)
    {
        if (_selectedUnits.Contains(unit))
        {
            ApplySelectionValues(false, unit);
            _selectedUnits.Remove(unit);
        }
    }

    public void DeselectAllUnits()
    {
        foreach (var unit in _selectedUnits)
        {
            ApplySelectionValues(false, unit);
        }
        _selectedUnits.Clear();
    }

    public List<Unit> GetSelectedUnits()
    {
        return _selectedUnits;
    }

    private void ApplySelectionValues(bool on_off, Unit unit)
    {
        unit.IsSelected = on_off;
        unit.SelectionIndicator.SetActive(on_off);
        unit.HealtBar.gameObject.SetActive(on_off);
    }
}
