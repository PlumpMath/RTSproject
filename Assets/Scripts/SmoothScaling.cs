using System.Runtime.Serialization.Formatters;
using UnityEngine;
using System.Collections;
/*
  For selection indicator (so far for units only)  
*/

public class SmoothScaling : MonoBehaviour
{

    public float ScaleTo;
    public float Duration;

    public Vector3 _original;
    public Vector3 _target;
    public bool _growing = true;

	void Awake ()
	{
	    _original = transform.localScale;
	}
	
	void Update ()
	{
	    _target = _original*ScaleTo;

	    if (_growing)
	    {
	        var nextSize = Vector3.Lerp(transform.localScale, _target, Time.deltaTime*Duration);
	        transform.localScale = nextSize;
	        if (_target.x - nextSize.x < 0.2f)
	            _growing = false;
	    }
	    else
	    {
            var nextSize = Vector3.Lerp(transform.localScale, _original, Time.deltaTime*Duration);
            transform.localScale = nextSize;
            if (nextSize.x - _original.x < 0.2f)
                _growing = true;
	    }
    }
}
