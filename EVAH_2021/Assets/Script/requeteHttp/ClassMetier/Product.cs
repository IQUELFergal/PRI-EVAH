using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : SequoiaElements
{
    public string name;
    public float temperature;
    public bool bacteries;
    public GameObject gameObject;
    public string text;
    public ProductType productType;
    public bool controlDone = false;
    public bool isColored = false;

    public Product(int id, string name, float temp, bool bacteries, ProductType proType):base(id)
    {
        
        this.temperature = temp;
        this.bacteries = bacteries;
        this.productType = proType;
        this.name = this.productType.label;
        this.text = " name = " + name + "\n temp = " + temp +"\n temp min/max = "+ this.productType.temperatureMin+ "/"+ this.productType.temperatureMax + "\n bacteries = " + bacteries;
        
    }
    public Product() {
       
    }

    public void MakeText()
    {
        this.text = " name = " + this.name + "\n temp = " + this.temperature + "\n temp min/max = " + this.productType.temperatureMin + "/" + this.productType.temperatureMax + "\n bacteries = " + this.bacteries;

    }


    public override string ToString()
    {
        return "id = " + id + " name = " + name + " temp = " + temperature + " bacteries = " + bacteries;
    }

}
