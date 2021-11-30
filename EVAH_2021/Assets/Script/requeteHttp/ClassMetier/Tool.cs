using System;
using UnityEngine;

public class Tool : SequoiaElements
{
	public string name;
	public ToolType toolType;
	public GameObject gameObject;

	public Tool() { }
	public Tool(int id, string name, ToolType tooltype):base(id)
	{
		this.name = name;
		this.toolType = tooltype;
	}
}
