using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using System.Collections;

[AddComponentMenu("Controlls/Selectable On Click")]
public class SelectableOnClick : MonoBehaviour
{
    private Unit _unit;
    private UnitManager _unitManager;

	void Awake ()
	{
	    _unit = GetComponent<Unit>();
	    _unitManager = GameObject.Find("PlayerUnitManager").GetComponent<UnitManager>();
	}


    void OnMouseUpAsButton()
    {
        if(!Input.GetKey(KeyCode.LeftShift))
            _unitManager.SelectSingleUnit(_unit);
        else
            _unitManager.SelectAditionalUnit(_unit);
    }
}
