using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : Subject
{

    float timer = 0.0f;
    [SerializeField]Text timeText;

    bool canNotify = true;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        double time = Mathf.Round(timer);
        if(time %15 == 0 && time!= 0)
        {
            if (canNotify)
            {
                NotifyObservers();
                canNotify = false;
            }
            //Debug.Log("15 second");
        }
        else
        {
            canNotify = true;
        }

        timeText.text = timer.ToString();

    }


    public void attachOb(Observer ob)
    {
        Attach(ob);
    }
}
