using UnityEngine;
using System.Collections;

[AddComponentMenu("Controlls/Selectable On Drag")]
public class SelectableOnDrag : MonoBehaviour
{
    public Renderer Mesh;

    private Unit _unit;
    private UnitManager _unitManager;

	void Awake ()
	{
	    _unit = GetComponent<Unit>();
	    _unitManager = GameObject.Find("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	void Update () 
    {
        if (Mesh.isVisible && Input.GetMouseButton(0) && !_unit.IsDead)
        {
            var camPos = Camera.main.WorldToScreenPoint(transform.position);
            camPos.y = DragSelection.InvertMouseY(camPos.y);

            if (DragSelection.SelectionBox.Contains(camPos))
            {
                if (!_unitManager.GetSelectedUnits().Contains(_unit))
                    _unitManager.SelectAditionalUnit(_unit); 
            }
            else
            {
                if (_unitManager.GetSelectedUnits().Contains(_unit))
                    _unitManager.DeselectSingleUnit(_unit);
            }
	    }
	}
}
