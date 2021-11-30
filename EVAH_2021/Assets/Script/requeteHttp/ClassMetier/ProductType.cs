using System;
using UnityEngine;

public class ProductType : SequoiaElements
{
    public string label;
    public float temperatureMin = -Mathf.Infinity;
    public float temperatureMax = Mathf.Infinity;
    

    public override string ToString()
    {
        return "id = " + id + " label = " + label + "; min = " + temperatureMin + "; max = " + temperatureMax;
    }
}
