using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Regions : MonoBehaviour
{
    private Toggle toggle;

    public TMP_Text Text;
    public Color ColorIsOn;
    public Color ColorIsOff;
    private void Start()
    {
        Text.color = ColorIsOff;
    }

    public void OnValueChange(bool isOn)
    {
        if (isOn)
        {
            Text.color = ColorIsOn;
        }
        else
        {
            Text.color = ColorIsOff;
        }
        
    }
}
