using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // variables
    // 1- objects 
    public GameObject spawener;
    public GameObject obstacle;

    // 2- time
    public float minTime = 100;
    public float maxTime = 2000;

    private float time = 0;
    private float spawnTime;

    // 3- game status
    public Movement player;
    // Start is called before the first frame update
    void Start()
    {

        SetRandomSpawnTime();
        time = minTime;
    }

    private void FixedUpdate()
    {
        if (!player.GameStatusIsOver())
        {
            time += Time.deltaTime;

            if (time >= spawnTime)
            {
                SpawenObject();
                SetRandomSpawnTime();
            }

        }
    }

    void SetRandomSpawnTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    void SpawenObject()
    {
        // set the time to 0 to restart the counter 
        time = 0;
        // spwen the obstacle
        Instantiate(obstacle, transform.position, spawener.transform.rotation);

    }

}
