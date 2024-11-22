using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : Observer
{

    [SerializeField]
    private Transform[] spawnLocations;

    [SerializeField] ObjectPool objectPool;


    int randomNum = 0;

    Timer time;

    int stage = 0;

    float timer = 0.0f;

    int stageTime = 10;

    bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        time = GameObject.Find("Timer").GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        double time = Mathf.Round(timer);

        if(time %stageTime == 0)
        {
            if (canSpawn)
            {
                spawnZombie();
                canSpawn = false;
            }
            //Zombie z = ObjectPool.CreateEnemy("Zombie", spawnLocations[randomNum].position, Quaternion.identity);

        }
        else
        {
            canSpawn = true;
        }


    }


    void spawnZombie()
    {
        randomNum = Random.Range(0, 5);
        Zombie z = ObjectPool.CreateEnemy("Zombie", spawnLocations[randomNum].position, Quaternion.identity);

    }

    public override void Notify(Subject subject)
    {
        stage++;
        if(stage >= 2)
        {
            stageTime = 5;
        }
    }
}
