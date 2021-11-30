using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script relié au comportement de l'etiquette 
public class Etiquette : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Food")
        {
            transform.GetComponent<Collider>().isTrigger = true;
            this.transform.parent = other.transform;
            Destroy(GetComponent("Throwable"));
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent("Interactable"));
        }
    }
}
