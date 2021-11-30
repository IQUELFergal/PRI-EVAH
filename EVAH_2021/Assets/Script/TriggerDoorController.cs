using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private string doorOpen = "";
    [SerializeField] private string doorClose = "";
    private string doorState;

    void Start()
    {
        doorState = "closed";
    }

    void OnHandHoverBegin() //hand enter the area, play animation
    {
        if(doorState == "closed")
        {
            myDoor.Play(doorOpen, 0, 0.0f);
        }
        else if(doorState == "opened")
        {
            myDoor.Play(doorClose, 0, 0.0f);
        }
    }

    void OnHandHoverEnd() //hand exit the area, change doorState
    {
        if(doorState == "closed")
        {
            doorState = "opened";
        }
        else if(doorState == "opened")
        {
            doorState = "closed";
        }
    }
}
