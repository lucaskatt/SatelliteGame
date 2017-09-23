using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Matter {

    public Explosion explosion;

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
            Explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NoGravZone")
        {
            useGravity = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid" && collision.rigidbody.velocity.magnitude > GetComponent<Rigidbody2D>().velocity.magnitude)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
