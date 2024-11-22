using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Observer
{
    Timer time;

    [SerializeField] ZombieSO zombieStats;

    Rigidbody rb;

    int stage = 0;

    int health = 3;


    bool isShoot = false;


    float timeToShoot = 2.0f;
    float timeSinceShoot = 0.0f;


    [SerializeField] GameObject bullet;

    [SerializeField] ZombieSpawner spawner;

    public override void Notify(Subject subject)
    {
        stage++;
    }

    // Start is called before the first frame update
    void Start()
    {
        time = GameObject.Find("Timer").GetComponent<Timer>();
        time.attachOb(this);

        rb = GetComponent<Rigidbody>();
        spawner = GameObject.Find("ZombieSpawner").GetComponent<ZombieSpawner>();
    }

    private void OnEnable()
    {
        int ranNum = Random.Range(0, 10);

        if(ranNum == 0)
        {
            isShoot = true;
        }
        else
        {
            isShoot = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, 0, -zombieStats._speed);

        if(health <= 0)
        {
            Die();
        }


        timeSinceShoot = timeSinceShoot + Time.deltaTime;

        if(isShoot && timeSinceShoot >= timeToShoot)
        {
            shoot();
            timeSinceShoot = 0.0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health--;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "End")
        {
            Time.timeScale = 0;
            Application.Quit();
        }
    }

    public void Die()
    {
        int ranNum = Random.Range(0, 2);
        
        if(ranNum == 0)
        {
            spawner.spawnZombie();
        }

        health = zombieStats._maxHealth;
        moneyManager.Instance.changeMoney(zombieStats._maxCoin);
        gameObject.SetActive(false);
    }

    void shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
