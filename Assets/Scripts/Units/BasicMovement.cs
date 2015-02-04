using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour
{
    private Unit _unit;
    private NavMeshAgent _agent;
    private Animation _animation;

	void Awake ()
	{
	    _unit = GetComponent<Unit>();
	    _agent = GetComponent<NavMeshAgent>();
	    _animation = GetComponent<Animation>();
	}

    void Start()
    {
        _agent.speed = _unit.Speed;
        _agent.acceleration = _unit.Acceleration;
        _agent.angularSpeed = _unit.RotationSpeed;
        _agent.SetDestination(transform.position);
    }
	
	void Update ()
	{
	    if (_unit.IsSelected && Input.GetMouseButtonDown(1))
	    {
	        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	        RaycastHit hit;
	        Physics.Raycast(ray, out hit);

	        if (hit.transform.gameObject.CompareTag("Walkable"))
	        {
                _agent.SetDestination(hit.point);
	        }
	    }


        if (_agent.velocity.z != 0 || _agent.velocity.x != 0)
        {
            _animation.CrossFade("run");
        }
        else if (_agent.velocity.z == 0 && _agent.velocity.x == 0)
        {
            _animation.CrossFade("idle");
        }
	}
}
