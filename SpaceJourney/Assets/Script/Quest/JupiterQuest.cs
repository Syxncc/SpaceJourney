using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JupiterQuest : MonoBehaviour
{
    public GameObject destination;
    public GameObject[] startLocation;
    public float spawnTime = 3f;
    public GameObject spawn;

    private GameObject currentSpawn;

    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        if (currentSpawn == null)
        {
            SpawnObject();
        }
    }


    IEnumerator DelaySpawn(float delayTime)
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(delayTime);
        SpawnObject();
    }

    void SpawnObject()
    {
        Transform spawnStartPosition = startLocation[Random.Range(0, startLocation.Length)].transform;
        // int sizeMultiplier = 10;
        // int meteorSize = sizeMultiplier * 20;
        GameObject newMeteor = Instantiate(spawn, spawnStartPosition.position, Quaternion.identity);
        currentSpawn = newMeteor;
        // newMeteor.transform.localScale = new Vector3(meteorSize, meteorSize, meteorSize);
        asteroidMotion asteroid = newMeteor.GetComponent<asteroidMotion>();
        // asteroid.trail.startWidth = 80 * sizeMultiplier;
        newMeteor.transform.LookAt(destination.transform);
        asteroid.minThrust = 700f;
        asteroid.maxThrust = 800f;
    }
}
