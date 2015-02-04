using UnityEngine;
using System.Collections;

public class OverHeadHealthBar : MonoBehaviour
{

    public Transform HealthBarPosition;

    private Transform _transform;

    void Awake()
    {
        _transform = transform;
    }
	void Start () 
    {
	
	}
	
	void Update ()
	{
	    var posOnScreen = Camera.main.WorldToScreenPoint(HealthBarPosition.position);

	    _transform.position = posOnScreen;
	}
}
