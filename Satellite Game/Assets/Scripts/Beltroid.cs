using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beltroid : Matter {

    public float initialVelocity;

	// Use this for initialization
	override protected void Start () {
		
        base.Start();
        FacePlanet();
        body.velocity = transform.right * initialVelocity;
	}

	// Update is called once per frame
	void Update () {
        FacePlanet();
	}

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
