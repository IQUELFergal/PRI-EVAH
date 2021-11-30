using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/* Changing the temperature variable will change the temperature that appear on the thermometer screeb*/
[ExecuteInEditMode]
public class ThermometerScreen : MonoBehaviour
{
    public float temperature;

    [SerializeField] TMP_Text text;

    private void Update()
    {
        if (text != null)
        {
            text.SetText(((int)temperature).ToString() + "°C");
        }
        else Debug.LogError("Error : can't find text");
    }
}
