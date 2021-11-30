using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/* This script will dislpay the hour on the screen (variable text) on every frame. 
 * The time start at 9:30 but this could easily be changed to another hour or the real time by changing the start time (hour of the day in second)*/
public class Clock : MonoBehaviour
{
    // Start is called before the first frame update
    public float start = 34200; //9h30
    private float timer;
   [SerializeField] TMP_Text text; 
    void Start()
    {
        timer = start;
        
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        text.SetText(GetHour());

    }

    string GetHour()
    {
        
        int hours = Mathf.FloorToInt(timer / 3600);
        int mins = Mathf.FloorToInt((timer % 3600) / 60);
        int secs = Mathf.FloorToInt(((timer % 3600) % 60));
        string Hour = hours.ToString() + ":" + mins.ToString();
        
        return Hour;
    }
}
