using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float explosionForce;

	// Use this for initialization
	void Start () {
        Invoke("SelfDestruct", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SelfDestruct()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Satellite" || collision.tag == "Asteroid")
        {
            Vector2 heading = collision.transform.position - transform.position;
            float distance = heading.magnitude;
            heading = heading / distance;
            float force = explosionForce;
            if (collision.tag == "Satellite")
            {
                force /= 2;
            }
            collision.GetComponent<Rigidbody2D>().AddForce(heading * force / (distance * distance));
        }
    }
}
