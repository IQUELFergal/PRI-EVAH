using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirty : MonoBehaviour
{
    Renderer rend;

    [Range(0,1)]
    public float dirtyness;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.SetFloat("Vector1_138F15F4", dirtyness);
    }
}
