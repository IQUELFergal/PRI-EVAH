using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etape
{
    public int id; 
    public string instruction;
    public GameObject objet;
    public Texture2D texture;
    public StopScenar arret = new StopScenar();
}
