using UnityEngine;
using System.Collections;

[AddComponentMenu("Controlls/Right Click To Set Destination")]
public class RightClickToSetDestination : MonoBehaviour
{
    public ParticleSystem MoveOrderEffect;

    private static ParticleSystem _orderEffect;
    private NavMeshAgent _agent;
    private Unit _unit;
    private UnitManager _unitManager;

	void Awake ()
	{
	    _agent = GetComponent<NavMeshAgent>();
	    _unit = GetComponent<Unit>();
	    _unitManager = GameObject.Find("PlayerUnitManager").GetComponent<UnitManager>();
	}

    void Start()
    {
        //_agent.SetDestination(transform.position);
        //if (_orderEffect == null)
        //{
        //    _orderEffect = Instantiate(MoveOrderEffect) as ParticleSystem;
        //    _orderEffect.Stop();
        //}
    }
	
	void Update ()
	{
        if (Input.GetMouseButtonDown(1))
        {
            var selectedUnits = _unitManager.GetSelectedUnits();
            if (selectedUnits.Count > 0)
            {
                var hit = GetHit();
                if (hit.transform.gameObject.CompareTag("Walkable"))
                {
                    foreach (var unit in selectedUnits)
                    {
                        unit.Target = null;
                        unit.Destination = hit.point;
                    }
                    Instantiate(MoveOrderEffect, hit.point, MoveOrderEffect.transform.rotation);
                }
            } 
        }

        //if (_unit.IsSelected && Input.GetMouseButtonDown(1))
        //{
        //    var hit = GetHit();

        //    if (hit.transform.gameObject.CompareTag("Walkable"))
        //    {
        //        _unit.Target = null;
        //        _unit.Destination = hit.point;
        //        if (_orderEffect.transform.position != hit.point)
        //        {
        //            _orderEffect.transform.position = hit.point;
        //            _orderEffect.Play(); 
        //        }
        //    }
        //}
    }

    private RaycastHit GetHit()
    {
        var ray= Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, Mathf.Infinity);
        
        return hit;
    }
}
