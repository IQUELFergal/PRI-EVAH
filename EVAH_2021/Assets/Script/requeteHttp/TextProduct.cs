using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TextProduct : MonoBehaviour
{
    public GameObject child;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {   /*
        if (text != null)
        {
            text.SetActive(false);
        }*/


        child = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnMouseOver()
    {
        if (text)
        {
            text.SetActive(true);
             
        }   
    }

    private void OnMouseExit()
    {
        if (text)
        {
            text.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tool"))
        {
            transform.GetComponent<Collider>().isTrigger = true;
            
            child.tag = "touche";
            Debug.Log("trigger a true");
            print(transform.GetComponent<Collider>().isTrigger);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tool"))
        {
            transform.GetComponent<Collider>().isTrigger = false;
            //child.SetActive(false);


            child.tag = "Untagged";
            Debug.Log("trigger a false");
            print(transform.GetComponent<Collider>().isTrigger);
        }
    }
}
