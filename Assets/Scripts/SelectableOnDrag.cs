using UnityEngine;
using System.Collections;

public class SelectableOnDrag : MonoBehaviour
{

    private Unit _unit;

	void Awake ()
	{
	    _unit = GetComponent<Unit>();
	}
	
	void Update () 
    {
        if (renderer.isVisible && Input.GetMouseButton(0) && DragSelection.SelectionBox.height > 20)
	    {
            if (!DragSelection.DragSelected.Contains(_unit))
            {
                var camPos = Camera.main.WorldToScreenPoint(transform.position);
                camPos.y = DragSelection.InvertMouseY(camPos.y);

                if (DragSelection.SelectionBox.Contains(camPos))
                    DragSelection.DragSelected.Add(_unit); 
            }
	    }
	}
}
