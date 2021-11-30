using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    // Start is called before the first frame update
    
    private bool isWorking;

    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isWorking == true)
        {
            GetComponent<Renderer>().material.color = Color.red;
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
            other.GetComponent<Food>().isCooking = true;
            transform.GetComponent<Collider>().isTrigger = true;
           
            
        }
        
    }
 /*   private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Food")
        {

            cooking = Cooking(other.GetComponent<Food>());
            StartCoroutine(cooking);

        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Food")
        {

            
            isWorking = false;
            other.GetComponent<Food>().isCooking = false;
            transform.GetComponent<Collider>().isTrigger = false;


        }
    }

}
