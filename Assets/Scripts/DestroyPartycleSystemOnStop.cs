using UnityEngine;
using System.Collections;

public class DestroyPartycleSystemOnStop : MonoBehaviour
{
	void Update () 
    {
	    if(!particleSystem.isPlaying)
            Destroy(gameObject);
	}
}
