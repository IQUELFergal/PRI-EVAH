using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isWorking;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWorking == true)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {

            
            isWorking = true;
            other.GetComponent<Food>().isCooling = true;
            transform.GetComponent<Collider>().isTrigger = true;


        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Food")
        {

            
            isWorking = false;
            other.GetComponent<Food>().isCooling = false;
            transform.GetComponent<Collider>().isTrigger = false;


        }
    }
}
