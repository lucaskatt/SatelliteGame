using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : Matter {

    public float initialVelocity;
    public float thrusterInitialVel;
    public float thrusterIncrement;

    private bool isThrusting = false;
    private float currentIncrement = 0;
    private Direction lastDir = Direction.none;

	// Use this for initialization
	override protected void Start () {
        base.Start();
        FacePlanet();
        body.velocity = Vector2.right * initialVelocity;
	}
	
	// Update is called once per frame
	void Update () {
        FacePlanet();
	}

    protected override void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
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
        }
        else
        {
            base.FixedUpdate();
            isThrusting = false;
        }
    }

    public void Thrust(Direction dir)
    {
        Vector2 heading;

        if (lastDir != dir)
        {
            isThrusting = false;
        }
        lastDir = dir;

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

        if (!isThrusting)
        {
            body.velocity = heading * thrusterInitialVel;
            currentIncrement = 0;
            isThrusting = true;
        }
        else
        {
            currentIncrement += thrusterIncrement;
            body.velocity = heading * thrusterInitialVel + heading * currentIncrement;
        }
    }

    public enum Direction
    {
        left,
        right,
        up,
        down,
        none
    }

}
