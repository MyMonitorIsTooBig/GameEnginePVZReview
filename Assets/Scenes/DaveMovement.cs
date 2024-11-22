using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaveMovement : MonoBehaviour
{

    int lane = 0;

    [SerializeField] private Transform[] daveLocations;

    [SerializeField] private GameObject bullet;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(lane!= 0)
            {
                lane = lane - 1;
            }
            else if(lane == 0)
            {
                lane = 4;
            }

            move();
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(lane!= 4)
            {
                lane = lane + 1;
            }
            else if(lane == 4)
            {
                lane = 0;
            }

            move();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }


    }

    private void shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }


    private void move()
    {

        if (daveLocations.Length == 5)
        {
            switch (lane)
            {
                case 0:
                    gameObject.transform.position = daveLocations[0].position;
                    break;
                case 1:
                    gameObject.transform.position = daveLocations[1].position;
                    break;
                case 2:
                    gameObject.transform.position = daveLocations[2].position;
                    break;
                case 3:
                    gameObject.transform.position = daveLocations[3].position;
                    break;
                case 4:
                    gameObject.transform.position = daveLocations[4].position;
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemybullet")
        {
            Debug.Log("hit bullet");
            Time.timeScale = 0;
            Application.Quit();
            
        }
    }

}
