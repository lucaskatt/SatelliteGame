using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Matter {

    private bool useGravity = true;

	// Use this for initialization
	override protected void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Initialize(float scale, float velocity, Vector2 target)
    {
        base.Start();
        transform.localScale = new Vector3(scale, scale, 1);

        Vector2 heading = (Vector3) target - transform.position;
        heading = heading / heading.magnitude;

        body.velocity = velocity * heading;
    }

    protected override void FixedUpdate()
    {
        if (useGravity)
        {
            base.FixedUpdate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NoGravZone")
        {
            useGravity = true;
        }

        if (collision.tag == "DestroyZone")
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NoGravZone")
        {
            useGravity = false;
        }
        
    }
}
