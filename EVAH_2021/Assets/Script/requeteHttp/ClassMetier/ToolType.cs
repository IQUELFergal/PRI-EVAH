using System;


public class ToolType : SequoiaElements
{
	public string label;
	
	public ToolType() { }
	public ToolType(int id, string label):base(id)
	{
		this.label = label;
	}
}
