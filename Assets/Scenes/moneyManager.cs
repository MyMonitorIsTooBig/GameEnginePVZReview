using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyManager : Singleton<moneyManager>
{


    int money = 0;

    GameObject[] zombies;

    [SerializeField]Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = money.ToString();
    }

    public void changeMoney(int mon)
    {
        money = money + mon;
    }


    public void PurchaseNuke()
    {
        if(money >= 50)
        {
            zombies = GameObject.FindGameObjectsWithTag("Zombie");
            
            foreach(GameObject i in zombies)
            {
                i.GetComponent<Zombie>().Die();
            }

            changeMoney(-50);
        }
    }
}
