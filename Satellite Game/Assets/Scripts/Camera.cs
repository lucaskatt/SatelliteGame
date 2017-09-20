using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Satellite satellite;

	// Use this for initialization
	void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 pos = satellite.transform.position;
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
	}
}
