using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//script relié au comportement des etagères
public class Shelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            transform.GetComponent<Collider>().isTrigger = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Food")
        {
            transform.GetComponent<Collider>().isTrigger = false;
        }
    }
}
