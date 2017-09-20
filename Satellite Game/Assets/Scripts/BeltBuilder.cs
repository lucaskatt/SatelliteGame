using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltBuilder : MonoBehaviour {

    public Beltroid beltroid;
    public int numRoids;
    public Planet planet;
    public float radius;
    public float maxVariance;

	// Use this for initialization
	void Start () {
        Build();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Build()
    {
        Vector2 center = planet.transform.position;

        for (int i = 0; i < numRoids; ++i)
        {
            float angle = i * 360 / numRoids;
            Vector2 pos = GetCirclePos(center, radius, angle);
            Beltroid roid = Instantiate(beltroid, pos, Quaternion.identity);
            roid.planet = planet;
        }
    }

    private Vector2 GetCirclePos(Vector2 center, float radius, float angle)
    {
        Vector2 pos;
        float xVar = Random.Range(-1 * maxVariance / 2, maxVariance / 2);
        float yVar = Random.Range(-1 * maxVariance / 2, maxVariance / 2);
        pos.x = center.x + radius * Mathf.Sin((angle + xVar) * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos((angle + yVar) * Mathf.Deg2Rad);
        return pos;
    }
}
