using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    public GameObject player;
    //public float dist_activation = 3.0f;
    public ParticleSystem water;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
        water.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //float distance = Vector3.Distance(transform.position,player.transform.position);
        
        /*if (distance < dist_activation)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            if (!water.isPlaying)
            {
                water.Play();

            }
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.red;
            water.GetComponent<ParticleSystem>().Stop();
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            if (!water.isPlaying)
            {
                water.Play();

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<Renderer>().material.color = Color.red;
            water.GetComponent<ParticleSystem>().Stop();
        }
    }
}
