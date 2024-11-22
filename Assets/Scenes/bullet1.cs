using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet1 : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private int speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0,0,-speed*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            Application.Quit();
        }
    }
}
