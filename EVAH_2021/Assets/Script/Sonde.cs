using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* When on collision, if the other GameObject has the tag Food, this will display it's temperature on the thermoter screen
 */
public class Sonde : MonoBehaviour
{
    // Start is called before the first frame update
    public ThermometerScreen thermometre;
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

            Debug.Log("trigger probe !!");
            thermometre.temperature = other.GetComponent<Food>().Temperature;
            transform.GetComponent<Collider>().isTrigger = true;


        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Food")
        {
            transform.GetComponent<Collider>().isTrigger = false;
        }
    }
}
