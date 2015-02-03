using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System.Collections;

public class SelectionManager : MonoBehaviour
{
    public Texture2D SelectionIndicator;
    
    public static List<Selectable> Units;
    public static Selectable Building;
    public static Rect SelectionBox;
    public static List<Selectable> BoxSelectionUnits;

    private Vector3 _startClick;

	void Start ()
    {
	    Units = new List<Selectable>(10);
        SelectionBox = new Rect(0, 0, 0, 0);
        BoxSelectionUnits = new List<Selectable>();
	    _startClick = -Vector3.one;
    }
	
	void Update ()
    {
        CheckForSelection();
        //CheckDeselection();
	}

    public void CheckForSelection()
    {
        // Multiple selection
        if (Input.GetMouseButtonDown(0))
        {
            _startClick = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_startClick == Input.mousePosition)
            {
                SelectWithMouse();
            }
            else
            {
                SelectMultiple(BoxSelectionUnits.ToArray());
                BoxSelectionUnits = new List<Selectable>();
            }
            _startClick = -Vector3.one;
        }

        if(Input.GetMouseButton(0))
        {
            SelectionBox = new Rect(
                _startClick.x, 
                InvertMouseY(_startClick.y), 
                Input.mousePosition.x - _startClick.x, 
                InvertMouseY(Input.mousePosition.y) - InvertMouseY(_startClick.y));

            if (SelectionBox.width < 0)
            {
                SelectionBox.x += SelectionBox.width;
                SelectionBox.width = -SelectionBox.width;
            }
            if (SelectionBox.height < 0)
            {
                SelectionBox.y += SelectionBox.height;
                SelectionBox.height = -SelectionBox.height;
            }
        }
    }

    // Selection cancelation by clicking on not selectable object
    private void CheckDeselection()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit) ||
                (!hit.transform.gameObject.CompareTag("Unit") && !hit.transform.gameObject.CompareTag("Building")))
            {
                DeselectAll();
            }
        }
    }

    private void OnGUI()
    {
        if (_startClick != -Vector3.one)
        {
            GUI.color = new Color(1, 1, 1, 0.5f);
            GUI.DrawTexture(SelectionBox, SelectionIndicator);
        }
    }

    public static float InvertMouseY(float y)
    {
        return Screen.height - y;
    }

    public static void SelectSingle(Selectable sel)
    {
        DeselectAll();

        if(sel.Type == Selectable.Types.Unit)
            Units.Add(sel);
        else if (sel.Type == Selectable.Types.Building)
            Building = sel;

        sel.Select();
    }

    public static void SelectMultiple(Selectable[] units)
    {
        DeselectAll();

        foreach (Selectable u in units)
        {
            u.Select();
        }

        Units = units.ToList();
    }

    public static void SelectWithMouse()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var s = hit.collider.GetComponent<Selectable>();
            if (s != null)
            {
                SelectSingle(s);
            }
        }
        //if (!sel.IsSelected && sel.Type == Selectable.Types.Unit)
        //{
        //    DeselectAll();

        //    sel.IsSelected = true;
        //    sel.SelectionIndicator.SetActive(true);
        //    SelectedUnits.Add(sel);
        //}
        //else if (!sel.IsSelected && sel.Type == Selectable.Types.Building)
        //{
        //    DeselectAll();

        //    sel.IsSelected = true;
        //    sel.SelectionIndicator.SetActive(true);
        //    SelectedBuilding = sel;
        //}
    }

    public static void DeselectAll()
    {
        foreach (var u in Units)
        {
            u.DeSelect();
        }

        Units = new List<Selectable>(10);

        if (Building != null)
        {
            Building.DeSelect();
            Building = null; 
        }
    }
}
