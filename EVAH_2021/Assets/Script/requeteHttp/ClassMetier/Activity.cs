using System;
using System.Collections.Generic;

public class Activity : SequoiaElements
{
	public int ordering;
	public Visual visual;
	public  List<ProductType> products;
	public int idOperator; 

	public Activity(int id,int ord, Visual visu, List<ProductType> prod):base(id)
    {
		this.ordering = ord;
		this.visual = visu;
		this.products = prod;

    }

	public override string ToString()
	{
		string rep = "operator id : " + id + " ordering: " + ordering + " visual : " + visual.icon + "/" + visual.name + " list product :";
        foreach (var p in products)
        {
			rep += "["+ p.ToString()+"]" ;
        }

		return rep;
	}
}
