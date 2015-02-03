using UnityEngine;
using System.Collections;

public class ClickToDeselect : MonoBehaviour
{

    private UnitManager _unitManager;

	void Start ()
	{
	    _unitManager = GameObject.Find("PlayerUnitManager").GetComponent<UnitManager>();
	}

    void Update()
    {
        if (renderer.isVisible && Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 40f))
            {
                if(gameObject.GetInstanceID() == hit.transform.gameObject.GetInstanceID())
                    _unitManager.DeselectAllUnits();
            }
        }
    }

    //void OnMouseDown()
    //{
    //    _unitManager.DeselectAllUnits();
    //}
}
