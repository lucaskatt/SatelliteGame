using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoidManager : MonoBehaviour {

    public Beltroid beltroid;
    public Planet planet;
    public Asteroid asteroid;
    public int numRoids;
    public float radius;
    public float maxBeltPosVariance;
    public float minAsteroidTargetDist;
    public float scaleVarianceIncrement;
    public float velVarianceIncrement;
    public float asteroidVel;
    public float asteroidFrequency;

    private List<Beltroid> beltroids;
    private float scaleVariance;
    private float velVariance;
    private const float timeToIncrement = 10;

	// Use this for initialization
	void Start () {
        BuildBelt();
        scaleVariance = scaleVarianceIncrement;
        velVariance = velVarianceIncrement;
        InvokeRepeating("SpawnAsteroid", 0, asteroidFrequency);
        InvokeRepeating("IncrementVariances", timeToIncrement, timeToIncrement);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BuildBelt()
    {
        Vector2 center = planet.transform.position;
        beltroids = new List<Beltroid>(numRoids);

        for (int i = 0; i < numRoids; ++i)
        {
            float angle = i * 360 / numRoids;
            Vector2 pos = GetCirclePos(center, radius, angle);
            Beltroid roid = Instantiate(beltroid, pos, Quaternion.identity);
            roid.planet = planet;
            beltroids.Add(roid);
        }
    }

    private Vector2 GetCirclePos(Vector2 center, float radius, float angle)
    {
        Vector2 pos;
        float xVar = Random.Range(-1 * maxBeltPosVariance / 2, maxBeltPosVariance / 2);
        float yVar = Random.Range(-1 * maxBeltPosVariance / 2, maxBeltPosVariance / 2);
        pos.x = center.x + radius * Mathf.Sin((angle + xVar) * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos((angle + yVar) * Mathf.Deg2Rad);
        return pos;
    }

    private void SpawnAsteroid()
    {
        Vector2 source = GetRandomBeltroidPos();
        Vector2 target = GetAsteroidTarget(source);
        Asteroid roid = Instantiate(asteroid, source, Quaternion.identity);
        roid.planet = planet;

        float scale = GetVariedValue(roid.transform.localScale.x, scaleVariance);
        float velocity = GetVariedValue(asteroidVel, velVariance);
        roid.Initialize(scale, velocity, target);

    }

    private Vector2 GetAsteroidTarget(Vector2 source)
    {
        Vector2 target;
        float dist = 0;

        do
        {
            target = GetRandomBeltroidPos();
            dist = Vector2.Distance(source, target);
        }
        while (dist < minAsteroidTargetDist);

        return target;
    }

    private Vector2 GetRandomBeltroidPos()
    {
        return beltroids[Random.Range(0, beltroids.Count)].transform.position;
    }

    private float GetVariedValue(float val, float variance)
    {
        return val + Random.Range(0, variance);
    }

    private void IncrementVariances()
    {
        scaleVariance += scaleVarianceIncrement;
        velVariance += velVarianceIncrement;
    }
}
