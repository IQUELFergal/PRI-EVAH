using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Echelle : MonoBehaviour
{
    //[SerializeField] Transform[] wheels = new Transform[4];
    [SerializeField] Vector3 lastObjectPosition = -Vector3.one;
    GameObject objectInRange = null;
    [SerializeField] string objectTag;
    Vector3[] rowPositions;
    [SerializeField] int selectedRow = -1;
    [SerializeField] int rowCount = 16;
    [SerializeField] Vector3 rowSize;
    [SerializeField] Vector3 basePos = Vector3.zero;
    [SerializeField] Vector3 rowOffset = Vector3.zero;
    bool isObjectMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rowPositions = new Vector3[rowCount];
        for (int i = 0; i < rowCount; i++)
        {
            rowPositions[i] = transform.position + basePos + Vector3.up * i * (rowSize.y + rowOffset.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(this.transform.position.x,0.8f, this.transform.position.z);
        this.transform.position = position;
        this.transform.rotation = new Quaternion(0, this.transform.rotation.y, 0,0);
        if (objectInRange != null && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MoveToPosition(2.5f));
        }

    }

    IEnumerator MoveToPosition(float duration)
    {
        Debug.Log("ping");
        isObjectMoving = true;
        lastObjectPosition = objectInRange.transform.position;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            objectInRange.transform.position = Vector3.Lerp(lastObjectPosition, rowPositions[selectedRow], (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isObjectMoving = false;
        Debug.Log("pong");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == objectTag)
        {
            Debug.Log("OnTriggerEnter");
            objectInRange = other.gameObject;
            if (lastObjectPosition == -Vector3.one)
            {
                lastObjectPosition = objectInRange.transform.position;
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == objectTag)
        {
            if (!isObjectMoving && Vector3.Distance(lastObjectPosition, other.transform.position) > 0.05f)
            {
                lastObjectPosition = objectInRange.transform.position;
                float distance = Mathf.Infinity;
                for (int i = 0; i < rowCount; i++)
                {
                    float newDistance = Vector3.Distance(objectInRange.transform.position, rowPositions[i]);
                    if (newDistance < distance)
                    {
                        distance = newDistance;
                        selectedRow = i;
                    }
                }
            }
            
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == objectTag)
        {
            Debug.Log("OnTriggerExit");
            objectInRange = null;
            selectedRow = -1;
            lastObjectPosition = -Vector3.one;
        }
    }


    private void OnDrawGizmos()
    {
        for (int i = 0; i < rowCount; i++)
        {
            //if (rowPositions.Length > 0) Gizmos.DrawCube(rowPositions[i], rowSize);
        }
        Gizmos.color = Color.green;
        if (selectedRow != -1)
        {
            Gizmos.DrawSphere(rowPositions[selectedRow], 0.025f);
            Gizmos.DrawLine(rowPositions[selectedRow], lastObjectPosition);
            //Gizmos.DrawCube(rowPositions[selectedRow], rowSize);
        }
    }

    
}
