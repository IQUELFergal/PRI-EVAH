using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : SequoiaElements
{
    public string type;
    public string description;
    public Form form; 
    public Visual visual;
    public List<ToolType> toolTypes = new List<ToolType>();
    public List<Tool> tools = new List<Tool>() ;
    public Task(int id, string type, Visual visu, string description, Form form) : base(id)
    {
        this.type = type;
        this.visual = visu;
        this.description = description;
        this.form = form;

    }

    public override string ToString()
    {
        return "task id : " + id + " type:" + type + " description: " + description + " icon: " + visual.icon + " name: " + visual.name + " form: "+form.data;
    }

}
