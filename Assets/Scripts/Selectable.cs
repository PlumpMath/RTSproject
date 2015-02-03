using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour
{
    public GameObject SelectionIndicator;
    public enum Types {Unit, Building}
    public Types Type;
    public bool IsSelected;
    public int ID { get; set; }

    void Awake()
    {
    }
	
	void Update () 
    {
	    if (renderer.isVisible && Type == Types.Unit && Input.GetMouseButtonUp(0) && SelectionManager.SelectionBox.height > 20)
	    {
	        var camPos = Camera.main.WorldToScreenPoint(transform.position);
	        camPos.y = SelectionManager.InvertMouseY(camPos.y);
	        
            if (SelectionManager.SelectionBox.Contains(camPos))
	        {
                SelectionManager.BoxSelectionUnits.Add(this);
	        }
	        else
	        {
	            if (SelectionManager.BoxSelectionUnits.Contains(this))
	            {
	                SelectionManager.BoxSelectionUnits.Remove(this);
	            }
	        }
	    }
	}

    public void Select()
    {
        IsSelected = true;
        SelectionIndicator.SetActive(true);
    }

    public void DeSelect()
    {
        IsSelected = false;
        SelectionIndicator.SetActive(false);
    }

    // Single selection
    private void OnMouseUpAsButton()
    {
        //if (!IsSelected)
        //{
        //    SelectionManager.DeselectAll();
        //    Select();
        //    if(Type == Types.Unit)
        //        SelectionManager.SelectedUnits.Add(this);
        //    else if (Type == Types.Building)
        //        SelectionManager.SelectedBuilding = this;
        //}

        //for(int i = 0; i < Selections.Length; i++)
        //{
        //    var s = Selections[i];
        //    if (s != null)
        //    {
        //        s.IsSelected = false;
        //        s.SelectionIndicator.SetActive(false);
        //        Selections[i] = null;
        //    }
        //}

        //IsSelected = true;
        //Selections[0] = this;
        //SelectionIndicator.SetActive(true);
    }
}
