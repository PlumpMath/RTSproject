using UnityEngine;
using System.Collections;

public class RightClickToMove : MonoBehaviour
{
    public GameObject MoveOrderEffect;

    private NavMeshAgent _agent;
    private Unit _unit;

	void Awake ()
	{
	    _agent = GetComponent<NavMeshAgent>();
	    _unit = GetComponent<Unit>();
	}

    void Start()
    {
        _agent.SetDestination(transform.position);
    }
	
	void Update () 
    {
	    if (_unit.IsSelected && Input.GetMouseButtonDown(1))
	    {
	        var pos = GetPosition();

	        if (pos != Vector3.zero)
	        {
	            _agent.SetDestination(pos);
	            Instantiate(MoveOrderEffect, pos, MoveOrderEffect.transform.rotation);
	        }
	    }
    }

    private Vector3 GetPosition()
    {
        var ray= Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 40f) && hit.transform.gameObject.CompareTag("Walkable"))
        {
            Debug.Log(hit.point);
            return hit.point;
        }

        return Vector3.zero;
    }
}
