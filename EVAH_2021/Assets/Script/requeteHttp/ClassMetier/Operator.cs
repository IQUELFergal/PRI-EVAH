using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operator : SequoiaElements
{
    public string name;
    public string forname;

    
    public Operator(int id,string name,string forname):base(id) 
    {
        this.name = name;
        this.forname = forname;
    }

    public override string ToString()
    {
        return "operator id : " + id + " name:" + name + " forname: " + forname;
    }
}
