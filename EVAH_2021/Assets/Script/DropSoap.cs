using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSoap : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem soap;
    public Color newColor;

    private Renderer targetRenderer;
    private Color actualColor;

    // Start is called before the first frame update
    void Start()
    {
        targetRenderer = target.GetComponent<Renderer>();
        actualColor = targetRenderer.material.color;
        soap.Stop();
    }

    void OnHandHoverBegin() //hand enter the area
    {
    	targetRenderer.material.color = newColor; //change "led" color 
        if(!soap.isPlaying)
        {
            soap.Play(); //play particle system
        }
    }

    void OnHandHoverEnd()
    {
        targetRenderer.material.color = actualColor; //reset "led" color
    }
}
