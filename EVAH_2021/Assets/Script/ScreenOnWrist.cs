using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ScreenOnWrist : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform thermometre_body;
    public Vector3 offset_position= new Vector3(-0.085f,0,-0.3f);
    public Vector3 offset_rotation=new Vector3(-120,0,0);
    
    void OnAttachedToHand(Hand hand)
    {

        Debug.Log("je suis tenu!");
        string hand_name = hand.gameObject.name;

        if (hand_name == "FallbackHand")
        {
            Debug.Log("Test Mode!");
            Transform hand_transform = hand.gameObject.transform;
            thermometre_body.GetComponent<Rigidbody>().isKinematic = true;
            thermometre_body.SetParent(hand_transform);
            thermometre_body.transform.position = new Vector3(hand_transform.position.x-1, hand_transform.position.y, hand_transform.position.z-2); 

            
        }
        else if (hand_name == "RightHand")
        {
            Transform hand_transform = hand.otherHand.gameObject.transform;
            thermometre_body.GetComponent<Rigidbody>().isKinematic = true;
            thermometre_body.SetParent(hand_transform);
            //thermometre_body.transform.position = hand_transform.position + offset_position;
            thermometre_body.transform.localPosition = offset_position;
            thermometre_body.transform.localEulerAngles = offset_rotation;
            thermometre_body.transform.localScale = Vector3.one;
            transform.localScale = Vector3.one*0.2f;
        }
        else if (hand_name == "LeftHand")
        {
            Transform hand_transform = hand.otherHand.gameObject.transform;
            thermometre_body.GetComponent<Rigidbody>().isKinematic = true;
            thermometre_body.SetParent(hand_transform);
            thermometre_body.transform.position = new Vector3(hand_transform.position.x, hand_transform.position.y, hand_transform.position.z);
        }


        Debug.Log("HAND :" + hand.gameObject.name) ;
    }

    void OnDetachedFromHand()
    {
        Debug.Log("je ne suis plus tenu !!");
        thermometre_body.SetParent(this.transform.parent);
        thermometre_body.GetComponent<Rigidbody>().isKinematic = false;
    }
}
