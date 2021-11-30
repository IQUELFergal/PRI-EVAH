using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script relié au condition d'arret d'une étape du scénario
public class StopCondition : MonoBehaviour
{
    public bool isStopCondition = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<ParticleSystem>())
        {

            if (transform.GetComponent<ParticleSystem>().isPlaying)
            {
                isStopCondition = true;
                print("StopCondition : is playing a true");
            }
            else if (!transform.GetComponent<ParticleSystem>().isPlaying)
            {
                isStopCondition = false;
            }
        }
        else
        {
            if (transform.tag == "Food")
            {
                if (transform.GetComponent<Food>().isCooling)
                {
                    if (transform.GetComponent<Food>().Temperature <= 10)
                    {
                        isStopCondition = true;
                    }
                    else
                    {
                        isStopCondition = false;
                    }
                }
                if (transform.GetComponent<Food>().isCooking)
                {
                    if (transform.GetComponent<Food>().Temperature >= 63)
                    {
                        isStopCondition = true;
                    }
                    else
                    {
                        isStopCondition = false;
                    }

                }
                if (!transform.GetComponent<Food>().isCooling && !transform.GetComponent<Food>().isCooking)
                {
                    isStopCondition = false;
                }

            }

            else
            {
                if (transform.GetComponent<Collider>().isTrigger)
                {
                    isStopCondition = true;
                }

                else if (!transform.GetComponent<Collider>().isTrigger)
                {
                    isStopCondition = false;
                }
            }

        }
    }
}
