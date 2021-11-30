using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem water;
    void Start()
    {
        water.Stop();
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            if (!water.isPlaying)
            {
                water.Play();

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
            water.GetComponent<ParticleSystem>().Stop();
        }
    }
}
