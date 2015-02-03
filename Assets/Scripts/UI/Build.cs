using UnityEngine;
using System.Collections;

public class Build : MonoBehaviour
{
    private Transform _obj;

	void Start () 
    {
	
	}
	
	void Update () 
    {
	    if (_obj != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(_obj.gameObject);
                _obj = null;
                return;
            }

            if (Input.GetMouseButtonUp(2))
            {
                _obj.GetComponentInChildren<NavMeshObstacle>().enabled = true;
                _obj = null;
                return;
            }

	        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	        RaycastHit hit;

	        if (Physics.Raycast(ray, out hit))
	        {
	            var pos = hit.point;
	            pos.y = 2.5f;
	            _obj.position = pos;
	        }
	    }
	}

    public void SpownBuilding(GameObject building)
    {
        var o = (GameObject) Instantiate(building);
        _obj = o.transform;
        _obj.GetComponentInChildren<NavMeshObstacle>().enabled = false;
    }
}
