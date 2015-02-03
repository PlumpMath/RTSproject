using UnityEngine;
using System.Collections;

public class ClickToDeselect : MonoBehaviour
{

    private UnitManager _unitManager;

	void Start ()
	{
	    _unitManager = GameObject.Find("PlayerUnitManager").GetComponent<UnitManager>();
	}

    void OnMouseUpAsButton()
    {
	    _unitManager.DeselectAllUnits();
	}
}
