using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matter : MonoBehaviour {

    public Planet planet;
    public float gravConst = 1;

    protected Rigidbody2D body;

	// Use this for initialization
	virtual protected void Start () {
        body = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    virtual protected void FixedUpdate()
    {
        Vector2 heading = (Vector2) planet.transform.position - body.position;
        heading.Normalize();
        body.AddForce(heading * CalculateGravitationalForce()); 
    }

    private float CalculateGravitationalForce()
    {
        float dist = Vector2.Distance(transform.position, planet.transform.position);
        return gravConst * body.mass * planet.mass / (dist);
    }
}
