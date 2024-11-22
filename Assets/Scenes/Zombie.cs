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
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, 0, -zombieStats._speed);

        if(health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("hit");
            health--;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "End")
        {
            Time.timeScale = 0;
        }
    }

    public void Die()
    {
        health = zombieStats._maxHealth;
        moneyManager.Instance.changeMoney(zombieStats._maxCoin);
        gameObject.SetActive(false);
    }
}
