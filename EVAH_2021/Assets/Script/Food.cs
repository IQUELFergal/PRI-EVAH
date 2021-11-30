using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    public float Temperature = 20;
    public bool isCooking;
    public bool isCooling;
    public string state;
    public bool changingTemp;

    void Start()
    {
        isCooking = false;
        gameObject.tag = "Food";
        state = "outside";
        changingTemp = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(isCooking == true)
            {
            Temperature += 1;
        }*/
        if(isCooking == true && changingTemp == true)
        {
            Invoke("Cooking", Random.Range(1.0f, 3.0f));
            changingTemp = false;
        }

        else if (isCooling == true && changingTemp == true)
        {
            Invoke("Cooling", Random.Range(1.0f, 3.0f));
            changingTemp = false;
        }

        /*if(changingTemp == true)
        {
            Invoke("ChangeTemperature", Random.Range(1.0f, 3.0f));
            changingTemp = false;
        }*/
    }

    void ChangeTemperature()
    {
        Debug.Log("temperature was changed");
        if( state == "outside")
        {
            Temperature += (float)0.1*Random.Range(-1, 2);
        }
        changingTemp = true;
        Debug.Log(Temperature);
    }

    void Cooking()
    {
        Temperature += 5;
        changingTemp = true;
        Debug.Log(Temperature);
    }


    void Cooling()
    {
        Temperature -= 5;
        changingTemp = true;
        Debug.Log(Temperature);
    }

}
