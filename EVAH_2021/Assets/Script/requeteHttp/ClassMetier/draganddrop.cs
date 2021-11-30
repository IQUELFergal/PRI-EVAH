using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draganddrop : MonoBehaviour
{
    private GameObject goName;
    private bool hasplayer=false;
    private bool beingCarried = false;
    private bool touched = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(gameObject.transform.position, GameObject.Find("FPSController").transform.position);
        if( dist <= 1.9f)
        {
            hasplayer = true;
            
        }
        else
        {
            hasplayer = false;
        }
        if (Input.GetKeyDown(KeyCode.E)&& hasplayer)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //goName.transform.position = GameObject.Find("eject").transform.position;
            gameObject.transform.parent = GameObject.Find("eject").transform;
            beingCarried = true;
        }

        if (beingCarried)
        {
            if (touched)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.transform.parent = null;
                beingCarried = false;   
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                objectup(0.5f);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                objectdown(0.5f);
            }
        }

    }

    public void objectup(float dist)
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + dist, transform.position.z);
    }
    public void objectdown(float dist)
    {

        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - dist, transform.position.z);
    }

    private void OnTriggerEnter()
    {
        if (beingCarried)
        {
            Debug.Log("enter triger");
            touched = true;
            

        }
    }
    /*
    private void OnTriggerExit()
    {
        if (col.gameObject.tag == "boite")
        {
            Debug.Log("exit triger");
            touched = false;
            
        }
    }*/
}
