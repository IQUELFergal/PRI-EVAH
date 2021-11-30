using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickNapkin : MonoBehaviour
{
	private Rigidbody napkinRb;
    private Collider napkinCollider;
    //private Transform transformNapkin;
    private Vector3 initialPosition;

    void Start()
    {
        napkinRb = this.GetComponent<Rigidbody>();
        napkinCollider = this.GetComponent<Collider>();
        initialPosition = this.transform.position; //save the position of napkin
    }

    void OnAttachedToHand() //when the player grab a napkin
    {
    	napkinRb.useGravity = true; //set gravity
        napkinCollider.isTrigger = false; //remove "Is trigger"

        if(this.transform.position == initialPosition) //if the napkin taken by the user is at the initial position (saved in Start())
        {
            PickNapkin clone = Instantiate(this, initialPosition, Quaternion.identity); //create new napkin at the initial position

            //reset the gravity and "is Kinematic" to false and "Is trigger" to true 
            Rigidbody cloneRb = clone.GetComponent<Rigidbody>();
            Collider cloneCollider = clone.GetComponent<Collider>();
            cloneRb.useGravity = false;
            cloneCollider.isTrigger = true;
            cloneRb.isKinematic = false; 
        }
    }
}