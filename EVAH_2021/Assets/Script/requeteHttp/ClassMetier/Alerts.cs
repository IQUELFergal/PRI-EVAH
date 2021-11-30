using System;

public class Alerts : SequoiaElements
{

	public Activity activity;
	public ActivityTask activityTask;
	public string lastControl;
	public int done;



	public Alerts(int id,Activity act, ActivityTask actTask, string last, int done) : base(id)
    {
		this.activity = act;
		this.activityTask = actTask;
		this.lastControl = last;
		this.done = done; 
    }

    public override string ToString()
    {
        //return "id : " + this.id + " activity [ " + this.activity.ToString() + "] activityTask [ " + this.activityTask.ToString() + "] lastcontrol : " + this.lastControl + " done : " + this.done;
		return "id : " + this.id + " activity " + this.activity.id + "activitytask " + activityTask.id + "\n";
	}
}
