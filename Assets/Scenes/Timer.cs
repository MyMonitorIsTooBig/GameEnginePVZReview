using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : Subject
{

    float timer = 0.0f;
    [SerializeField]Text timeText;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;


        if(timer %60 == 0)
        {
            NotifyObservers();
        }

        timeText.text = timer.ToString();

    }


    public void attachOb(Observer ob)
    {
        Attach(ob);
    }
}
