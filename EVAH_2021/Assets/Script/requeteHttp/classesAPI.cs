using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Authentification
{
    public string username;
    public string password;
}

public class ResponsePing
{
    public int result;
    public string[] messages;
    public PingAPI data;
}
public class ResponseAuth
{
    public int result;
    public string[] messages;
    public Auth data;
}
public class ResponseTaskAPI
{
    public int result;
    public string[] messages;
    public TaskAPI[] data;
}
public class ResponseOperatorAPI
{
    public int result;
    public string[] messages;
    public OperatorAPI[] data;
}
public class ResponseControlAPIPost
{
    public int result;
    public string[] messages;
    public RControlAPI data;
}
public class ResponseControlAPI
{
    public int result;
    public string[] messages;
    public ControlAPI data;
}
public class ResponseActivityTaskAPI
{
    public int result;
    public string[] messages;
    public ActivityTaskAPI[] data;
}
public class ResponseActivityAPI
{
    public int result;
    public string[] messages;
    public ActivityAPI[] data;
}

public class ResponseAlertsAPI
{
    public int result;
    public string[] messages;
    public AlertsAPI[] data;
}

public class AlertsAPI
{
    public int activity_id, activitytask_id;
    public string last_ctrl;
    public int done; 
}



public class ActivityAPI 
{
    public int id;
    public string name, icon, products;
    public int ordering;
}

public class ActivityTaskAPI 
{
    public int id, task_id, activity_id;
    public string frequency, date_start, date_end,target;
    public string target_id;

}

public class RControlAPI
{
    public string id; 
}
public class ControlAPI 
{
    public string uid, date_created;
    public int activitytask_id;
    public string date_control;
    public List<FormValueAPI> form_value; 
    public string comment, author;
}

public class FormValueAPI
{
    public string uid, value;
    public MetadataAPI metadata = new MetadataAPI();
}

public class MetadataAPI
{
    public string id, label;
    public ValueAPI value = new ValueAPI();
}

public class ValueAPI
{
    public string min, max;
}
public class OperatorAPI 
{
    public int id;
    public string forename, name;

}
public class TaskAPI 
{
    public int id;
    public string name, type, description, icon, form;

}

public class PingAPI 
{
    public string result;
    public string version;
}

public class Auth  
{
    public InstancesList instance;
    public InstancesList[] instancesList;
    public string token;
}
public class InstancesList
{
    public string id;
    public string name;
}


public class InstanceSwitch
{
    public int instance_id;

}

public class ReponsePing
{
    public int result;
    public string[] messages;
    public PingAPI data;
}
public class ReponseAuth
{
    public int result;
    public string[] messages;
    public Auth data;
}



public class Value
{
    public float min = -Mathf.Infinity;
    public float max = Mathf.Infinity;
}
public class ID
{
    public int id;
    public string label;
    public Value value;
}



