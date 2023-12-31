using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxTime = 1;
    private float timer = 0;
    private GameObject asteroids;
    public GameObject scoreTrigger;
    public List<GameObject> asteroidGroups = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        asteroids = asteroidGroups[Random.Range(0, asteroidGroups.Count)];
        
        GameObject newAsteroids = Instantiate(asteroids);
        newAsteroids.transform.position = transform.position;

        GameObject newScoreTrigger = Instantiate(scoreTrigger);
        newScoreTrigger.transform.parent = newAsteroids.transform;
        newScoreTrigger.transform.position = newAsteroids.transform.position;
        Destroy(newAsteroids, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            asteroids = asteroidGroups[Random.Range(0, asteroidGroups.Count)];
            GameObject newAsteroids = Instantiate(asteroids);
            newAsteroids.transform.position = transform.position;
            GameObject newScoreTrigger = Instantiate(scoreTrigger);
            newScoreTrigger.transform.parent = newAsteroids.transform;
            newScoreTrigger.transform.position = newAsteroids.transform.position;
            Destroy(newAsteroids, 15);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
