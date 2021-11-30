using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTimeUnderWater : MonoBehaviour
{
	public Canvas canvas;

	private Slider slider;
	private Text txt;
	private float time;
	private float maxtime = 30f; //the user has to stay 30 seconds under water
	private int count;

	void Start()
	{
		canvas.gameObject.SetActive(false);
		slider = canvas.transform.GetChild(0).GetComponent<Slider>(); //get component Slider from canvas
		time = 0;
    	slider.maxValue = maxtime;
    	slider.value = time;
    	count = 0;
	}

	//count when hands enter or exit the area to know when the user has two hands under water
	void OnHandHoverBegin()
	{
		count++;	
	}

	void OnHandHoverEnd()
	{
		count--;
	}

	void HandHoverUpdate()
	{
		if(count == 2) //if two hands have entered the trigger area
		{
			time += Time.deltaTime;
    		if (time < maxtime)
    		{
    	   		slider.value = time;
    		}
    		else
    		{
        		canvas.gameObject.SetActive(false); //when the slider is full, hide it
        		//Hands are now clean
    		}
		}
	}
}
