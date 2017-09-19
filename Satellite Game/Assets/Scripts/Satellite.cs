using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : Matter {

    public float initialVelocity;
    public float thrusterForce;

    private float escapeVelocity;

	// Use this for initialization
	override protected void Start () {
        base.Start();
        body.velocity = Vector2.right * initialVelocity;
	}
	
	// Update is called once per frame
	void Update () {
        transform.up = -1 * (planet.transform.position - transform.position);
	}

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (Input.GetAxis("Horizontal") > 0)
        {
            Thrust(Direction.right);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            Thrust(Direction.left);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            Thrust(Direction.up);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            Thrust(Direction.down);
        }

        escapeVelocity = CalculateEscapeVelocity();
        
    }

    public void Thrust(Direction dir)
    {
        Vector2 heading;

        switch (dir)
        {
            case Direction.left:
                heading = -1 * transform.right;
                break;
            case Direction.right:
                heading = transform.right;
                break;
            case Direction.up:
                heading = transform.up;
                break;
            case Direction.down:
                heading = -1 * transform.up;
                break;
            default:
                heading = Vector2.zero;
                break;
        }

        body.AddForce(heading * thrusterForce);

    }

    //need to set max velocity
    private float CalculateEscapeVelocity()
    {
        return 0;
    }

    public enum Direction
    {
        left,
        right,
        up,
        down
    }

}
