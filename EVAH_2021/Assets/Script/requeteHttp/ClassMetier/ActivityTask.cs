using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityTask : SequoiaElements
{
    public string frequency;
    public string dateStart;
    public string dateEnd;
    public Activity activity;
    public Task task;
    public string idTarget;
    public string target;

    public ActivityTask(int id, string freq, string dstart, string dend,Activity act, Task task , string idTar, string target ) : base(id)
    {
        this.frequency = freq;
        this.dateStart = dstart;
        this.dateEnd = dend;
        this.activity = act;
        this.task = task;
        this.idTarget = idTar;
        this.target = target;
    }

    public override string ToString()
    {
        return "ActivityTask id : " +id+ ", Frequency : "+ frequency+", date start/date end : "+dateStart +"/" + dateEnd+", Activity : "+ activity.visual.name+ ", task: " + task.visual.name + ", id target: " + idTarget + ", target : " +target;
    }

}
