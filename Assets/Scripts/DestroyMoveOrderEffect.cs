using UnityEngine;
using System.Collections;

public class DestroyMoveOrderEffect : MonoBehaviour {

	
	void Update () 
    {
	    if(!particleSystem.isPlaying)
            Destroy(gameObject);
	}
}
